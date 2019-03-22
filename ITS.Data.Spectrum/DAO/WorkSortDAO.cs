using ITS.Core.RoadRepairing.DataInterfaces;
using ITS.Core.RoadRepairing.Domain;
using ITS.ProjectBase.Data;

namespace ITS.Data.RoadRepairing.DAO
{
   public class WorkSortDAO : AbstractNHibernateDAO<WorkSort, long>, IWorkSortDAO
    {
        /// <summary>
        /// Создает слой доступа к данным по объектам.
        /// </summary>
        /// <param name="sessionFactoryConfigPath">Путь к фабрике NHibernate.</param>
        public WorkSortDAO(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {

        }

        public override WorkSort Save(WorkSort entity)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                   session.SaveOrUpdate(entity);
                   t.Commit();
                }
            }
            return entity;
        }

        public override void Delete(WorkSort entity)
        {
            using (var session = NHibernateSession)
            {
                using (var t = session.BeginTransaction())
                {
                    session.Delete(entity);
                    t.Commit();
                }
            }
        }
        

    }
}
