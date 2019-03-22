using System.Collections.Generic;
using ITS.Core.Domain.Organizations;
using ITS.Core.Spectrum.Domain;
using ITS.ProjectBase.Data;

namespace ITS.Core.Spectrum.DataInterfaces
{
    public interface IAdvertismentDAO : IDAO<Advertisment, long>
    {
        List<Advertisment> GetAdvertisementsByOrganizationList(List<Organization> orgs);
        Advertisment LoadAdvertisementData(Advertisment advertisement);
    }
}