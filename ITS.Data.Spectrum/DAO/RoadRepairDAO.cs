using System.Collections.Generic;
using System.Linq;
using ITS.Core.RoadRepairing.DataInterfaces;
using ITS.Core.RoadRepairing.Domain;
using ITS.ProjectBase.Data;
using NHibernate.Criterion;
using ITS.Core.Domain.FeatureObjects;
using NHibernate.Spatial.Criterion;
using NHibernate;
using System;
using ITS.Core.Enums;
using ITS.Core.RoadRepairing.Domain.Enums;
using GeoAPI.Geometries;
using ITS.Core.Domain.Districts;
using ITS.Core.ManagerInterfaces.Districts;

namespace ITS.Data.RoadRepairing.DAO
{
    public class RoadRepairDAO : AbstractNHibernateDAO<RoadRepair, long>, IRoadRepairDAO
    {
      
        /// <summary>
        /// Создает слой доступа к данным по объектам типа "Ремонт".
        /// </summary>
        /// <param name="sessionFactoryConfigPath">Путь к фабрике NHibernate.</param>
        public RoadRepairDAO(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
           
        }

        #region IRoadRepairDAO Members

        public override RoadRepair Save(RoadRepair entity)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                    var envelope = entity.FeatureObject.Geometry.EnvelopeInternal;
                    session.SaveOrUpdate(entity);
                    envelope.ExpandToInclude(entity.FeatureObject.Geometry.EnvelopeInternal);
                    UpdateMapGrid(entity, envelope, session);
                   
                    t.Commit();
                }
            }
            return entity;
        }

        public override void Delete(RoadRepair entity)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                    session.Delete(entity);
                    var envelope = entity.FeatureObject.Geometry.EnvelopeInternal;
                    var q = session.CreateCriteria<MapGrid>("mg")
                        .Add(Restrictions.Eq("mg.Map.ID", entity.FeatureObject.Layer.Map.ID))
                        .Add(SpatialRestrictions.Filter("mg.Bounds", envelope, 4326));
                    var mapGridList = q.List<MapGrid>();
                    foreach (var mapGrid in mapGridList)
                    {
                        session.Lock(mapGrid, LockMode.Force);
                    }
                    t.Commit();
                }
            }
         
        }


        private void UpdateMapGrid(RoadRepair entity, Envelope envelope, ISession session)
        {
            var q = session.CreateCriteria<MapGrid>("mg")
                .Add(Restrictions.Eq("mg.Map.ID", entity.FeatureObject.Layer.Map.ID))
                .Add(SpatialRestrictions.Filter("mg.Bounds", envelope, 4326));
            var mapGridList = q.List<MapGrid>();
            foreach (var mapGrid in mapGridList)
            {
                session.Lock(mapGrid, LockMode.Force);
            }
        }

        /// <summary>
        /// Получить Ремонт по геометрии.
        /// </summary>
        /// <param name="featureId">Идентификатор геометрии.</param>
        /// <returns>Ремонт, использующий эту геометрию.</returns>
        public RoadRepair GetByFeature(long featureId)
        {
            using (var session = NHibernateSession)
            {
                var list = session.QueryOver<RoadRepair>()
                    .Where(x => x.FeatureObject != null && x.FeatureObject.ID == featureId)
                    .List();
                return list != null ? list.FirstOrDefault() : null;
            }
        }

        /// <summary>
        /// Возвращает список объектовДорожный ремонт по списку ИД геометрий
        /// Испольхуется в LayerLoader
        /// </summary>
        /// <param name="ids">Список ИД геометрий</param>
        /// <returns>Список объектовДорожный ремонт</returns>
        public List<RoadRepair> GetRoadRepairsByFeatureObjectIDs(List<long> ids)
        {
            using (ISession session = NHibernateSession)
            {
                var q = session.QueryOver<RoadRepair>().Where(p => p.FeatureObject.ID.IsIn(ids));
                return q.List<RoadRepair>().ToList();
            }
        }


        /// <summary>
        /// Возвращает список описаний работ, соответствующих типу ремонта и работ
        /// </summary>
        //public List<string> GetDescribeByRepairWorkType(RepairType rt, WorkType wt)
        //{
        //    List<string> res = new List<string>();
        //    using (ISession session = NHibernateSession)
        //    {
        //        var q = session.QueryOver<WorkSort>().Where(ws => ((ws.RepairType.Type==rt) && (ws.WorkType.Type==wt))).List();
        //        res.AddRange(q.Select(worksort => worksort.Name));
        //        return res;
        //    }
        //}
        public IEnumerable<RoadRepair> FindRoadRepairsByDateStart(DateTime ds)
        {
            using (ISession session = NHibernateSession)
            {
                using (session.BeginTransaction())
                {
                    ICriteria criteria = session.CreateCriteria<RoadRepair>("b");
                    criteria.Add(Restrictions.In("RepairStart.Year", new List<int>() {ds.Year}));
                    var list = criteria.List<RoadRepair>();
                    return list;
                }
            }
        }

       /// <summary>
        /// Получить строковое описаниеДорожный ремонта.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>ИдДорожный ремонта, строковое описаниеДорожный ремонта.</returns>
        public Dictionary<long, string> GetObjectIdDescription(long featureId)
        {
            using (var session = NHibernateSession)
            {
                Dictionary<long, string> rr = new Dictionary<long, string>();
                var roadrepair = session.QueryOver<RoadRepair>()
                    .Where(x => x.FeatureObject != null && x.FeatureObject.ID == featureId)
                    .List().FirstOrDefault();
                if (roadrepair != null) rr.Add(roadrepair.ID, roadrepair.ToString());
                return rr;
            }
        }

        /// <summary>
        /// Получить список строковых описанийДорожный ремонтов.
        /// </summary>
        /// <param name="featureIds">Список индентификаторов геометрий.</param>
        /// <returns>Список строковых описанийДорожный ремонтов.</returns>
        public Dictionary<long, Dictionary<long, string>> GetFeatureIdObjectIdDescription(IEnumerable<long> featureIds)
        {
            using (ISession session = NHibernateSession)
            {
                var q = session.QueryOver<RoadRepair>().WhereRestrictionOn(p => p.FeatureObject.ID).IsIn(featureIds.ToArray());
                return q.List<RoadRepair>().ToDictionary(r => r.FeatureObject.ID, r => new Dictionary<long, string>(1) { { r.ID, r.ToString() } });
            }
        }

        /// <summary>
        /// Получение версии геометрии.
        /// </summary>
        /// <param name="featureId">Ид геометрии.</param>
        /// <returns>Версия геометрии.</returns>
        public int GetFeatureVersion(long featureId)
        {
            using (ISession session = NHibernateSession)
            {
                var firstOrDefault = session.QueryOver<FeatureObject>().Where(f => f != null && f.ID == featureId).List().FirstOrDefault();
                if (firstOrDefault != null)
                {
                    var q = firstOrDefault.Version;
                    return q;
                }
            }
            return 0;
        }


        
        /// <summary>
        /// Фильтр DTO ЖД переезды.
        /// </summary>
        /// <param name="roadrepairFilters">Коллекция фильтров.</param>
        /// <returns>ЖД переезды DTO.</returns>
        public IEnumerable<RoadRepairDTO> FilterRoadRepairs(ICollection<ITS.Core.Domain.Filters.Filter> roadrepairFilters)
        {
            if (roadrepairFilters == null)
            {
                throw new ArgumentNullException("roadrepairFilters", "фильтр не должен быть пустым");
            }

            using (var session = NHibernateSession)
            {
                var criteria = session.CreateCriteria<RoadRepair>("rr").CreateAlias("rr.FeatureObject", "f");

                var aliases = new Dictionary<string, string>
                {
                    {"rr.FeatureObject", "f"},
                };
                var result = new List<RoadRepairDTO>();
                {
                    Filtrate(criteria, roadrepairFilters, aliases, "rr");
                    var data = criteria.List<RoadRepair>().Distinct();
                    result.AddRange(data.Select(row => new RoadRepairDTO
                    {
                        RoadRepairId = row.ID,
                        Address = GetAddressByRoadRepairId(row.ID),
                        RepairType = row.RepairType,
                        WorkType = row.WorkType,
                        WorkSort = row.WorkSort,
                        Status = row.Status,
                        RepairStart = row.RepairStart,
                        RepairEnd = row.RepairEnd,
                        RepairStartFact = row.RepairStartFact,
                        RepairEndFact = row.RepairEndFact,
                        Performer = row.Performer,
                        Customer = row.Customer,
                        Owner = row.Owner,
                        FeatureObject = row.FeatureObject,
                    }).ToList());
                }
                return result;
            }
        }

        
        /// <summary>
        /// Установить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">Дорожная работы.</param>
        /// <returns>Установлен ли адрес для дорожной работы.</returns>
        public void SetAddressForRoadRepair(long addressId, long roadRepairId)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {

                    var insert = session.CreateSQLQuery(
                            "INSERT INTO rr_address_roadrepair(roadrepair_id, address_id) " +
                            "VALUES (:RoadRepairId, :AddressId)")
                        .SetInt64("RoadRepairId", roadRepairId)
                        .SetInt64("AddressId", addressId)
                        .ExecuteUpdate();
                    t.Commit();
                }

            }
        }

        /// <summary>
        /// Удалить адрес для дорожной работы.
        /// </summary>
        /// <param name="addressId">ID адреса.</param>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удален ли адрес для дорожной работы.</returns>
        public bool DeleteAddressForRoadRepair(long addressId, long roadRepairId)
        {
            int res = 0;
            using (ISession session = NHibernateSession)
            {
                using (ITransaction t = session.BeginTransaction())
                {
                    res = session.CreateSQLQuery("DELETE FROM rr_address_roadrepair " +
                        "WHERE id_roadrepair = :RoadRepairId AND id_address = :AddressId")
                        .SetInt64("RoadRepairId", roadRepairId)
                        .SetInt64("AddressId", addressId)
                        .ExecuteUpdate();
                    t.Commit();
                }
            }

            return res > 0;
        }

        /// <summary>
        /// Удалить все адреса для дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Удалены ли адреса для дорожной работы.</returns>
        public bool DeleteAllAddressesForRoadRepair(long roadRepairId)
        {
            int res = 0;
            using (ISession session = NHibernateSession)
            {
                using (ITransaction t = session.BeginTransaction())
                {
                    res = session.CreateSQLQuery("DELETE FROM rr_address_roadrepair " +
                        "WHERE id_roadrepair = :RoadRepairId")
                        .SetInt64("RoadRepairId", roadRepairId)
                        .ExecuteUpdate();
                    t.Commit();
                }
            }

            return res > 0;
        }

        /// <summary>
        /// Получить Ид адреса по Ид дорожной работы.
        /// </summary>
        /// <param name="roadRepairId">ID дорожной работы.</param>
        /// <returns>Ид адреса дорожной работы.</returns>
        //TODO: адаптировать под несколько одинаковых ид ремонтов с разными адресами.
        public long? GetAddressIdByRoadRepairId(long roadRepairId)
        {
            List<long> foundIds = null;
            using (ISession session = NHibernateSession)
            {
                foundIds = session.CreateSQLQuery(
                    "SELECT id_address FROM rr_address_roadrepair " +
                    "WHERE id_roadrepair = :RoadRepairId")
                    .SetInt64("RoadRepairId", roadRepairId)
                    .List<long>().ToList();

                if (foundIds.Any())
                {
                    return foundIds.First();
                }
            }

            return null;
        }

        /// <summary>
        ///TODO: Потом сделать для нескольких адресов
        /// </summary>
        /// <param name="roadRepairId"></param>
        /// <returns></returns>
        public Address GetAddressByRoadRepairId(long roadRepairId)
        {
            List<long> foundAddresses;
            using (ISession session = NHibernateSession)
            {
                foundAddresses = session.CreateSQLQuery(
                        "SELECT address_id FROM rr_address_roadrepair " +
                        "WHERE roadrepair_id = :RoadRepairId")
                    .SetInt64("RoadRepairId", roadRepairId)
                    .List<long>().ToList();
                if (foundAddresses.Any())
                {
                    var list = session.QueryOver<Address>()
                        .Where(x => x.ID.IsIn(foundAddresses))
                        .List();
                    return list.First();
                }
            }

            return null;

        }

        /// <summary>
        /// Получение максимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Максимальное значение.</returns>
        public int GetMaxValue(string paramName)
        {
            using (var session = NHibernateSession)
            {
                var criteria = session.CreateCriteria<RoadRepair>();
                switch (paramName)
                {
                    case "BeginKm":
                        {
                            return (int)Math.Ceiling(criteria.SetProjection(Projections.Max(paramName)).UniqueResult<double?>() ?? 0);
                        }
                    case "EndKm":
                        {
                            return (int)Math.Ceiling(criteria.SetProjection(Projections.Max(paramName)).UniqueResult<double?>() ?? 0);
                        }
                    default:
                        {
                            return 1;
                        }
                }
            }
        }

        /// <summary>
        /// Получение минимального значения.
        /// </summary>
        /// <param name="paramName">Имя свойства.</param>
        /// <returns>Минимальное значение.</returns>
        public int GetMinValue(string paramName)
        {
            using (var session = NHibernateSession)
            {
                var criteria = session.CreateCriteria<RoadRepair>();
                switch (paramName)
                {
                    case "BeginKm":
                        {
                            return (int)Math.Floor(criteria.SetProjection(Projections.Min(paramName)).UniqueResult<double?>() ?? 0);
                        }
                    case "EndKm":
                        {
                            return (int)Math.Floor(criteria.SetProjection(Projections.Min(paramName)).UniqueResult<double?>() ?? 0);
                        }
                    default:
                        {
                            return 0;
                        }
                }
            }
        }
        #region Private Methods

        private void Filtrate(ICriteria criteria, IEnumerable<Core.Domain.Filters.Filter> filters, Dictionary<string, string> aliases, string rootAlias)
        {
            var i = 0;
            foreach (var filter in filters)
            {
                if (!filter.Values.Any()) continue;

                criteria.Add(GetExpression(filter,
                    GetPropertyAlias(filter, aliases, rootAlias, ref i, (s, s1) => criteria.CreateAlias(s, s1))));
            }

        }

        private string GetPropertyAlias(Core.Domain.Filters.Filter filter, Dictionary<string, string> aliases, string rootAlias, ref int i, Action<string, string> action)
        {
            var pathNodes = new List<string>(filter.PropertyPath.Split('.'));
            var aliasName = rootAlias;
            var currentPath = aliasName;
            while (pathNodes.Count > 1)
            {
                var prop = pathNodes.First();
                currentPath += "." + prop;
                if (!aliases.Keys.Contains(currentPath))
                {
                    action(aliasName + "." + prop, aliasName = "a" + i++);
                    aliases.Add(currentPath, aliasName);
                }
                else
                {
                    aliasName = aliases[currentPath];
                }
                pathNodes.RemoveAt(0);
            }
            var propName = pathNodes[0];
            return aliasName + "." + propName;
        }

        private AbstractCriterion GetExpression(Core.Domain.Filters.Filter filter, string propName)
        {
            switch (filter.Function)
            {
                case FilterFunc.Eq:
                    if (filter.Values.Length > 1)
                    {
                        var expression = Restrictions.Or(Restrictions.Eq(propName, filter.Values[0]),
                            Restrictions.Eq(propName, filter.Values[1]));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression, Restrictions.Eq(propName, filter.Values[j]));
                        }
                        return expression;
                    }
                    return Restrictions.Eq(propName, filter.Values.First());
                case FilterFunc.Le:
                    return Restrictions.Le(propName, filter.Values.First());
                case FilterFunc.Lt:
                    return Restrictions.Lt(propName, filter.Values.First());
                case FilterFunc.Ge:
                    return Restrictions.Ge(propName, filter.Values.First());
                case FilterFunc.Gt:
                    return Restrictions.Gt(propName, filter.Values.First());
                case FilterFunc.In:
                    return Restrictions.In(propName, filter.Values);
                case FilterFunc.Between:
                    return Restrictions.Between(propName, filter.Values[0], filter.Values[1]);
                case FilterFunc.Like:
                    if (filter.FilterType != FilterType.String) break;
                    if (filter.Values.Length > 1)
                    {
                        var expression =
                            Restrictions.Or(Restrictions.Like(propName, (string)filter.Values[0], MatchMode.Anywhere),
                                Restrictions.Like(propName, (string)filter.Values[1], MatchMode.Anywhere));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression,
                                Restrictions.Like(propName, (string)filter.Values[j], MatchMode.Anywhere));
                        }
                        return expression;
                    }
                    return Restrictions.Like(propName, (string)filter.Values.First(), MatchMode.Anywhere);
                case FilterFunc.InsensitiveLike:
                    if (filter.FilterType != FilterType.String) break;
                    if (filter.Values.Length > 1)
                    {
                        var expression =
                            Restrictions.Or(
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[0], MatchMode.Anywhere),
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[1], MatchMode.Anywhere));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression,
                                Restrictions.InsensitiveLike(propName, (string)filter.Values[j], MatchMode.Anywhere));
                        }
                        return expression;
                    }
                    return Restrictions.InsensitiveLike(propName, (string)filter.Values.First(), MatchMode.Anywhere);
                case FilterFunc.Nullable:
                    return Restrictions.IsNull(propName);
                case FilterFunc.Id:
                    if (filter.Values.Length > 1)
                    {
                        var expression = Restrictions.Or(Restrictions.Eq(propName, long.Parse(filter.Values[0].ToString())),
                            Restrictions.Eq(propName, long.Parse(filter.Values[1].ToString())));
                        for (var j = 2; j < filter.Values.Length; j++)
                        {
                            expression = Restrictions.Or(expression, Restrictions.Eq(propName, long.Parse(filter.Values[j].ToString())));
                        }
                        return expression;
                    }
                    return Restrictions.Eq(propName, long.Parse(filter.Values.First().ToString()));
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return null;
        }

        #endregion
        #endregion

    }
}
