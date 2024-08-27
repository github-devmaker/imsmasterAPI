using imsmasterApi.Contexts;
using WebApplication2.Models;

namespace imsmasterApi
{
    public class Services
    {
        public dynamic getFilterFac3IotMcL8(MOther obj)
        {
            DbIoTFac3Line8 dbIoTFac3Line8 = new DbIoTFac3Line8();
            string fac = obj.fac;
            string line = obj.line;
            string proId = (obj.proId != "" && obj.proId != null) ? obj.proId.ToString() : "";
            var result = (from mstProd in dbIoTFac3Line8.McEtdMstPrograms.ToList()
                          join prodDetail in dbIoTFac3Line8.McEtdProgramDetails
                          on mstProd.ProId equals prodDetail.ProId
                          join mstModel in dbIoTFac3Line8.McEtdMstModels
                          on prodDetail.MId equals mstModel.MId
                          select new { mstProd.ProId, mstProd.ProName, prodDetail.MId, mstModel.MName }).ToList();
            if (proId == "")
            {
                proId = result.ToList()[0].ProId.ToString();
            }
            var listModel = result.Where(x => x.ProId.ToString() == proId).ToList().DistinctBy(x => x.MName).OrderBy(x => x.MName);
            var modelSelected = listModel.ToList().Count > 0 ? listModel.ToList()[0].MId : "";
            return new { id = proId, program = result.DistinctBy(x => x.ProName), model = listModel, modelSelected = modelSelected };
        }
    }
}
