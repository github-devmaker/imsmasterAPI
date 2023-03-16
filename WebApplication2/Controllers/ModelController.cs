using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Validations;
using System.Data;
using WebApplication2.Contexts;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("")]
    [ApiController]
    public class ModelController : Controller
    {
        private readonly DbIoTFac1 _contextFac1;
        private readonly DbIoTFac2 _contextFac2;
        private readonly DbIoTFac3Line6 _contextFac3Line6;
        private readonly DbIoTFac3Line8 _contextFac3Line8;
        private readonly DbSCM _contextDbSCM;
        private readonly DbHRM _contextDbHRM;

        public ModelController(DbIoTFac1 contextFac1, DbIoTFac2 contextFac2, DbIoTFac3Line6 contextFac3Line6, DbIoTFac3Line8 contextFac3Line8, DbSCM contextDbSCM, DbHRM contextDbHRM)
        {
            _contextFac1 = contextFac1;
            _contextFac2 = contextFac2;
            _contextFac3Line6 = contextFac3Line6;
            _contextFac3Line8 = contextFac3Line8;
            _contextDbSCM = contextDbSCM;
            _contextDbHRM = contextDbHRM;
        }

        [HttpPost]
        [Route("/filter")]
        public async Task<IActionResult> getFilter([FromBody] MOther? prams)
        {
            string fac = prams.fac;
            string line = prams.line;
            string proId = (prams.proId != "" && prams.proId != null) ? prams.proId.ToString() : "";
            //string proId = (prams.proId != "" && prams.proId != null) ? prams.proId : "";
            if (fac == "1")
            {
                return Ok(_contextFac1.getFilter(prams));
            }
            else if (fac == "2")
            {
                return Ok(_contextFac2.getFilter(prams));
            }
            else if (fac == "3")
            {
               if (line == "Mecha line 8")
                {
                    return Ok(_contextFac3Line8.getFilter(prams));
                }
                else
                {
                    return Ok(_contextFac3Line6.getFilter(prams));
                }
            }
            else
            {
                return BadRequest(prams);
            }
        }

        [HttpPost]
        [Route("/getall")]
        public async Task<IActionResult> getAll ([FromBody] MOther prams)
        {
            string proId = prams.proId;
            string line = prams.line;
            string model = prams.model;
            if (prams.fac == "1")
            {
                var ProgramDetail = _contextFac1.EtdProgramDetails.ToList();
                if (proId != "")
                {
                    ProgramDetail = ProgramDetail.Where(x => x.ProId.ToString() == proId).ToList();
                }
                if (model != "")
                {
                    ProgramDetail = ProgramDetail.Where(x => x.MId == model).ToList();
                }
                var mIdList = ProgramDetail.Select(s => s.MId).ToList();
                if (ProgramDetail.Count > 0)
                {
                    var a = _contextFac1.EtdModelDetails.Where(x => mIdList.Select(x => x).Contains(x.MId)).ToList();
                    var b = _contextFac1.EtdMstParts.ToList();
                    var c = _contextFac1.EtdMstPartTypes.ToList();
                    var dbGroupRank = _contextFac1.EtdGroupRanks.ToList();
                    var dbModelStd = _contextFac1.EtdMstModels.ToList();
                    var result = from x in a
                                 join groupRank in dbGroupRank
                                 on x.RId equals groupRank.GId
                                 join modelStd in dbModelStd
                                 on x.MId equals modelStd.MId
                                 join y in b
                                 on x.PId equals y.PId.ToString()
                                 join z in c
                                 on x.PtId equals z.PtId.ToString()
                                 //where x.PStatus == true
                                 select new { x.PId,x.PtId,x.RId, groupRank.RName, y.PName, z.PtName, modelStd.MId, modelStd.MName, x.PMidDimension, x.PMaxDimension, x.PMinDimension, x.PCycletime, x.PDate, x.PUser, x.PStatus };
                    return Ok(result);
                }
            }
            else if (prams.fac == "2")
            {
               if (line == "Machine")
                {
                    var ProgramDetail = _contextFac2.McEtdProgramDetails.ToList();
                    if (proId != "")
                    {
                        ProgramDetail = _contextFac2.McEtdProgramDetails.Where(x => x.ProId.ToString() == proId).ToList();
                    }
                    if (model != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.MId == model).ToList();
                    }
                    var mIdList = ProgramDetail.Select(s => s.MId).ToList();
                    if (ProgramDetail.Count > 0)
                    {
                        var a = _contextFac2.McEtdModelDetails.Where(x => mIdList.Select(x => x).Contains(x.MId)).ToList();
                        var b = _contextFac2.McEtdMstParts.ToList();
                        var c = _contextFac2.McEtdMstPartTypes.ToList();
                        var dbGroupRank = _contextFac2.McEtdGroupRanks.ToList();
                        var dbModelStd = _contextFac2.McEtdMstModels.ToList();
                        var result = from x in a
                                     join groupRank in dbGroupRank
                                     on x.RId equals groupRank.GId
                                     join modelStd in dbModelStd
                                     on x.MId equals modelStd.MId
                                     join y in b
                                     on x.PId equals y.PId.ToString()
                                     join z in c
                                     on x.PtId equals z.PtId.ToString()
                                     select new { x.PId, x.PtId, x.RId, groupRank.RName, y.PName, z.PtName, modelStd.MId, modelStd.MName, x.PMidDimension, x.PMaxDimension, x.PMinDimension, x.PCycletime, x.PDate, x.PUser, x.PStatus };
                        return Ok(result);
                    }
                }
                else
                {
                    var ProgramDetail = _contextFac2.EtdProgramDetails.ToList();
                    if (proId != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.ProId.ToString() == proId).ToList();
                    }
                    if (model != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.MId == model).ToList();
                    }
                    var mIdList = ProgramDetail.Select(s => s.MId).ToList();
                    if (ProgramDetail.Count > 0)
                    {
                        var a = _contextFac2.EtdModelDetails.Where(x => mIdList.Select(x => x).Contains(x.MId)).ToList();
                        var b = _contextFac2.EtdMstParts.ToList();
                        var c = _contextFac2.EtdMstPartTypes.ToList();
                        var dbGroupRank = _contextFac2.EtdGroupRanks.ToList();
                        var dbModelStd = _contextFac2.EtdMstModels.ToList();
                        var result = from x in a
                                     join groupRank in dbGroupRank
                                     on x.RId equals groupRank.GId
                                     join modelStd in dbModelStd
                                     on x.MId equals modelStd.MId
                                     join y in b
                                     on x.PId equals y.PId.ToString()
                                     join z in c
                                     on x.PtId equals z.PtId.ToString()
                                     select new { x.PId, x.PtId, x.RId, groupRank.RName, y.PName, z.PtName, modelStd.MId, modelStd.MName, x.PMidDimension, x.PMaxDimension, x.PMinDimension, x.PCycletime, x.PDate, x.PUser, x.PStatus };
                        return Ok(result);
                    }
                }
                return Ok(new { });
            }
            else if (prams.fac == "3")
            {
                if (prams.line == "Mecha line 8")
                {
                    var ProgramDetail = _contextFac3Line8.McEtdProgramDetails.ToList();
                    if (proId != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.ProId.ToString() == proId).ToList();
                    }
                    if (model != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.MId == model).ToList();
                    }
                    var mIdList = ProgramDetail.Select(s => s.MId).ToList();

                    if (ProgramDetail.Count > 0)
                    {
                        var a = _contextFac3Line8.McEtdModelDetails.Where(x => mIdList.Select(x => x).Contains(x.MId)).ToList();
                        var b = _contextFac3Line8.McEtdMstParts.ToList();
                        var c = _contextFac3Line8.McEtdMstPartTypes.ToList();
                        var dbGroupRank = _contextFac3Line8.McEtdGroupRanks.ToList();
                        var dbModelStd = _contextFac3Line8.McEtdMstModels.ToList();
                        var result = from x in a
                                     join groupRank in dbGroupRank
                                     on x.RId equals groupRank.GId
                                     join modelStd in dbModelStd
                                     on x.MId equals modelStd.MId
                                     join y in b
                                     on x.PId equals y.PId.ToString()
                                     join z in c
                                     on x.PtId equals z.PtId.ToString()
                                     //where x.PStatus == true
                                     select new { x.PId, x.PtId, x.RId, groupRank.RName, y.PName, z.PtName, modelStd.MId, modelStd.MName, x.PMidDimension, x.PMaxDimension, x.PMinDimension, x.PCycletime, x.PDate, x.PUser, x.PStatus };
                        return Ok(result);
                    }
                }
                else
                {
                    var ProgramDetail = _contextFac3Line6.EtdProgramDetails.ToList();
                    if (proId != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.ProId.ToString() == proId).ToList();
                    }
                    if (model != "")
                    {
                        ProgramDetail = ProgramDetail.Where(x => x.MId == model).ToList();
                    }
                    var mIdList = ProgramDetail.Select(s => s.MId).ToList();
                    if (ProgramDetail.Count > 0)
                    {
                        var a = _contextFac3Line6.EtdModelDetails.Where(x => mIdList.Select(x => x).Contains(x.MId)).ToList();
                        var b = _contextFac3Line6.EtdMstParts.ToList();
                        var c = _contextFac3Line6.EtdMstPartTypes.ToList();
                        var dbGroupRank = _contextFac3Line6.EtdGroupRanks.ToList();
                        var dbModelStd = _contextFac3Line6.EtdMstModels.ToList();
                        var result = from x in a
                                     join groupRank in dbGroupRank
                                     on x.RId equals groupRank.GId
                                     join modelStd in dbModelStd
                                     on x.MId equals modelStd.MId
                                     join y in b
                                     on x.PId equals y.PId.ToString()
                                     join z in c
                                     on x.PtId equals z.PtId.ToString()
                                     //where x.PStatus == true
                                     select new { x.PId, x.PtId, x.RId, groupRank.RName, y.PName, z.PtName, modelStd.MId, modelStd.MName, x.PMidDimension, x.PMaxDimension, x.PMinDimension, x.PCycletime, x.PDate, x.PUser, x.PStatus };
                        return Ok(result);
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("/model/exist/")]
        public async Task<IActionResult> existMid([FromBody] MModel data)
        {
            string fac = data.Fac;
            string line = data.Line;
            int count = 0;
            var context = _contextDbSCM.PnCompressors.Where(x => x.ModelCode == data.NewModelCode).FirstOrDefault();
            if (fac == "1")
            {
                count = _contextFac1.EtdModelDetails.Where(x => x.MId == data.NewModelCode).Count();
            }
            else if (fac == "2")
            {
                if (line == "Machine")
                {
                    count = _contextFac2.McEtdModelDetails.Where(x => x.MId == data.NewModelCode).Count();
                }
                else
                {
                    count = _contextFac2.EtdModelDetails.Where(x => x.MId == data.NewModelCode).Count();
                }
            }
            else if (fac == "3")
            {
                if (line == "Mecha line 8")
                {
                    count = _contextFac3Line8.McEtdModelDetails.Where(x => x.MId == data.NewModelCode).Count();
                }
                else
                {
                    count = _contextFac3Line6.EtdModelDetails.Where(x => x.MId == data.NewModelCode).Count();
                }
            }
            return Ok(new { content=context,count=count });
        }

        [HttpPost]
        [Route("/model/add/")]
        public async Task<ActionResult> addModel([FromBody] MModel data)
        {
            if (data.Fac == "1")
            {
                int contextProgramDetail = _contextFac1.EtdProgramDetails.Where(x => x.ProId == data.ProId && x.MId == data.NewModelCode).Count();
                if (contextProgramDetail == 0)
                {
                    EtdProgramDetail item = new EtdProgramDetail();
                    item.MId = data.NewModelCode;
                    item.ProId = Convert.ToInt32(data.ProId);
                    _contextFac1.EtdProgramDetails.Add(item);
                    _contextFac1.SaveChanges();
                }
                var contextMstModel = _contextFac1.EtdMstModels.SingleOrDefault(x => x.MId == data.NewModelCode);
                if (contextMstModel == null)
                {
                    EtdMstModel item = new EtdMstModel();
                    item.MId = data.NewModelCode;
                    item.MName = data.NewModelName;
                    item.MDate = DateTime.Now;
                    item.MUser = "IT";
                    _contextFac1.EtdMstModels.Add(item);
                    _contextFac1.SaveChanges();
                }
                else
                {
                    contextMstModel.MName = data.NewModelName;
                    contextMstModel.MDate = DateTime.Now;
                    contextMstModel.MUser = "IT";
                    _contextFac1.Update(contextMstModel);
                    _contextFac1.SaveChanges();
                }

                int countInsert = 0;
                var context = _contextFac1.EtdModelDetails.Where(x => x.MId == data.MId).ToList();
                foreach(var item in context)
                {
                    item.MId = data.NewModelCode;
                    item.PDate = DateTime.Now;
                    item.PUser = "IT";
                    int exist = _contextFac1.EtdModelDetails.Where(x => x.MId == data.NewModelCode && x.PId == item.PId && x.PtId == item.PtId && x.RId == item.RId).Count();
                    if (exist == 0)
                    {
                        _contextFac1.Add(item);
                        countInsert++;
                    }
                }
                if(countInsert > 0)
                {
                    int effInsert = await _contextFac1.SaveChangesAsync();
                    if (effInsert < 0)
                    {
                        return BadRequest(new { mes = false });
                    }
                }
                return Ok(new { mes = true });
            }
            else if (data.Fac == "2")
            {
                if (data.Line == "Machine")
                {
                    int contextProgramDetail = _contextFac2.McEtdProgramDetails.Where(x => x.ProId == data.ProId && x.MId == data.NewModelCode).Count();
                    if (contextProgramDetail == 0)
                    {
                        McEtdProgramDetail item = new McEtdProgramDetail();
                        item.MId = data.NewModelCode;
                        item.ProId = Convert.ToInt32(data.ProId);
                        _contextFac2.McEtdProgramDetails.Add(item);
                        _contextFac2.SaveChanges();
                    }
                    var contextMstModel = _contextFac2.McEtdMstModels.SingleOrDefault(x => x.MId == data.NewModelCode);
                    if (contextMstModel == null)
                    {
                        McEtdMstModel item = new McEtdMstModel();
                        item.MId = data.NewModelCode;
                        item.MName = data.NewModelName;
                        item.MDate = DateTime.Now;
                        item.MUser = "IT";
                        _contextFac2.McEtdMstModels.Add(item);
                        _contextFac2.SaveChanges();
                    }
                    else
                    {
                        contextMstModel.MName = data.NewModelName;
                        contextMstModel.MDate = DateTime.Now;
                        contextMstModel.MUser = "IT";
                        _contextFac2.Update(contextMstModel);
                        _contextFac2.SaveChanges();
                    }

                    int countInsert = 0;
                    var context = _contextFac2.McEtdModelDetails.Where(x => x.MId == data.MId).ToList();
                    foreach (var item in context)
                    {
                        item.MId = data.NewModelCode;
                        item.PDate = DateTime.Now;
                        item.PUser = "IT";
                        int exist = _contextFac2.McEtdModelDetails.Where(x => x.MId == data.NewModelCode && x.PId == item.PId && x.PtId == item.PtId && x.RId == item.RId).Count();
                        if (exist == 0)
                        {
                            _contextFac2.Add(item);
                            countInsert++;
                        }
                    }
                    if (countInsert > 0)
                    {
                        int effInsert = await _contextFac2.SaveChangesAsync();
                        if (effInsert < 0)
                        {
                            return Ok(new { mes = false });
                        }
                    }
                    return Ok(new { mes = true });
                }
                else
                {
                    int contextProgramDetail = _contextFac2.EtdProgramDetails.Where(x => x.ProId == data.ProId && x.MId == data.NewModelCode).Count();
                    if (contextProgramDetail == 0)
                    {
                        EtdProgramDetail item = new EtdProgramDetail();
                        item.MId = data.NewModelCode;
                        item.ProId = Convert.ToInt32(data.ProId);
                        _contextFac2.EtdProgramDetails.Add(item);
                        _contextFac2.SaveChanges();
                    }
                    var contextMstModel = _contextFac2.EtdMstModels.SingleOrDefault(x => x.MId == data.NewModelCode);
                    if (contextMstModel == null)
                    {
                        EtdMstModel item = new EtdMstModel();
                        item.MId = data.NewModelCode;
                        item.MName = data.NewModelName;
                        item.MDate = DateTime.Now;
                        item.MUser = "IT";
                        _contextFac2.EtdMstModels.Add(item);
                        _contextFac2.SaveChanges();
                    }
                    else
                    {
                        contextMstModel.MName = data.NewModelName;
                        contextMstModel.MDate = DateTime.Now;
                        contextMstModel.MUser = "IT";
                        _contextFac2.Update(contextMstModel);
                        _contextFac2.SaveChanges();
                    }

                    int countInsert = 0;
                    var context = _contextFac2.EtdModelDetails.Where(x => x.MId == data.MId).ToList();
                    foreach (var item in context)
                    {
                        item.MId = data.NewModelCode;
                        item.PDate = DateTime.Now;
                        item.PUser = "IT";
                        int exist = _contextFac2.EtdModelDetails.Where(x => x.MId == data.NewModelCode && x.PId == item.PId && x.PtId == item.PtId && x.RId == item.RId).Count();
                        if (exist == 0)
                        {
                            _contextFac2.Add(item);
                            countInsert++;
                        }
                    }
                    if (countInsert > 0)
                    {
                        int effInsert = await _contextFac2.SaveChangesAsync();
                        if (effInsert < 0)
                        {
                            return Ok(new { mes = false });
                        }
                    }
                    return Ok(new { mes = true });
                }
            }
            else if (data.Fac == "3")
            {
                if (data.Line == "Mecha line 8")
                {
                    int contextProgramDetail = _contextFac3Line8.McEtdProgramDetails.Where(x => x.ProId == data.ProId && x.MId == data.NewModelCode).Count();
                    if (contextProgramDetail == 0)
                    {
                        McEtdProgramDetail item = new McEtdProgramDetail();
                        item.MId = data.NewModelCode;
                        item.ProId = Convert.ToInt32(data.ProId);
                        _contextFac3Line8.McEtdProgramDetails.Add(item);
                        _contextFac3Line8.SaveChanges();
                    }
                    var contextMstModel = _contextFac3Line8.McEtdMstModels.SingleOrDefault(x => x.MId == data.NewModelCode);
                    if (contextMstModel == null)
                    {
                        McEtdMstModel item = new McEtdMstModel();
                        item.MId = data.NewModelCode;
                        item.MName = data.NewModelName;
                        item.MDate = DateTime.Now;
                        item.MUser = "IT";
                        _contextFac3Line8.McEtdMstModels.Add(item);
                        _contextFac3Line8.SaveChanges();
                    }
                    else
                    {
                        contextMstModel.MName = data.NewModelName;
                        contextMstModel.MDate = DateTime.Now;
                        contextMstModel.MUser = "IT";
                        _contextFac3Line8.Update(contextMstModel);
                        _contextFac3Line8.SaveChanges();
                    }

                    int countInsert = 0;
                    var context = _contextFac3Line8.McEtdModelDetails.Where(x => x.MId == data.MId).ToList();
                    foreach (var item in context)
                    {
                        item.MId = data.NewModelCode;
                        item.PDate = DateTime.Now;
                        item.PUser = "IT";
                        int exist = _contextFac3Line8.McEtdModelDetails.Where(x => x.MId == data.NewModelCode && x.PId == item.PId && x.PtId == item.PtId && x.RId == item.RId).Count();
                        if (exist == 0)
                        {
                            _contextFac3Line8.Add(item);
                            countInsert++;
                        }
                    }
                    if (countInsert > 0)
                    {
                        int effInsert = await _contextFac3Line8.SaveChangesAsync();
                        if (effInsert < 0)
                        {
                            return Ok(new { mes = false });
                        }
                    }
                    return Ok(new { mes = true });
                }
                else
                {
                    int contextProgramDetail = _contextFac3Line6.EtdProgramDetails.Where(x => x.ProId == data.ProId && x.MId == data.NewModelCode).Count();
                    if (contextProgramDetail == 0)
                    {
                        EtdProgramDetail item = new EtdProgramDetail();
                        item.MId = data.NewModelCode;
                        item.ProId = Convert.ToInt32(data.ProId);
                        _contextFac3Line6.EtdProgramDetails.Add(item);
                        _contextFac3Line6.SaveChanges();
                    }
                    var contextMstModel = _contextFac3Line6.EtdMstModels.SingleOrDefault(x => x.MId == data.NewModelCode);
                    if (contextMstModel == null)
                    {
                        EtdMstModel item = new EtdMstModel();
                        item.MId = data.NewModelCode;
                        item.MName = data.NewModelName;
                        item.MDate = DateTime.Now;
                        item.MUser = "IT";
                        _contextFac3Line6.EtdMstModels.Add(item);
                        _contextFac3Line6.SaveChanges();
                    }
                    else
                    {
                        contextMstModel.MName = data.NewModelName;
                        contextMstModel.MDate = DateTime.Now;
                        contextMstModel.MUser = "IT";
                        _contextFac3Line6.Update(contextMstModel);
                        _contextFac3Line6.SaveChanges();
                    }

                    int countInsert = 0;
                    var context = _contextFac3Line6.EtdModelDetails.Where(x => x.MId == data.MId).ToList();
                    foreach (var item in context)
                    {
                        item.MId = data.NewModelCode;
                        item.PDate = DateTime.Now;
                        item.PUser = "IT";
                        int exist = _contextFac3Line6.EtdModelDetails.Where(x => x.MId == data.NewModelCode && x.PId == item.PId && x.PtId == item.PtId && x.RId == item.RId).Count();
                        if (exist == 0)
                        {
                            _contextFac3Line6.Add(item);
                            countInsert++;
                        }
                    }
                    if (countInsert > 0)
                    {
                        int effInsert = await _contextFac3Line6.SaveChangesAsync();
                        if (effInsert < 0)
                        {
                            return Ok(new { mes = false });
                        }
                    }
                    return Ok(new { mes = true });
                }
            }
            return BadRequest();
        }


        //[HttpPost]
        //[Route("/filter/model")]
        //public async Task<IActionResult> getFilterModel(MOther prams)
        //{
        //    string line = prams.line;
        //    string proId = prams.proId;
        //    if (prams.fac == "1")
        //    {
        //        var context = _contextFac1.EtdMstPrograms.ToList();
        //        if (proId != "")
        //        {
        //            context = context.Where(x=>x.ProId.ToString() == proId).ToList();
        //        }
        //        var result = from mstProg in context
        //                   join progDetail in _contextFac1.EtdProgramDetails.ToList()
        //                   on mstProg.ProId equals progDetail.ProId
        //                   join mstModel in _contextFac1.EtdMstModels.ToList()
        //                   on progDetail.MId equals mstModel.MId
        //                   select new { mstModel.MId,mstModel.MName };
        //        return Ok(result);
        //    }
        //    else if (prams.fac == "2")
        //    {
        //        if (line == "Mecha")
        //        {
        //            var context =  _contextFac2.EtdMstPrograms.ToList();
        //            if (proId != "")
        //            {
        //                context = context.Where(x => x.ProId.ToString() == proId).ToList();
        //            }
        //            var result = from mstProg in context
        //                         join progDetail in _contextFac2.EtdProgramDetails.ToList()
        //                         on mstProg.ProId equals progDetail.ProId
        //                         join mstModel in _contextFac2.EtdMstModels.ToList()
        //                         on progDetail.MId equals mstModel.MId
        //                         select new { mstModel.MId, mstModel.MName };
        //            return Ok(result);
        //        }
        //        else
        //        {
        //            var context = _contextFac2.McEtdMstPrograms.ToList();
        //            if (proId != "")
        //            {
        //                context = context.Where(x => x.ProId.ToString() == proId).ToList();
        //            }
        //            var result = from mstProg in context
        //                         join progDetail in _contextFac2.EtdProgramDetails.ToList()
        //                         on mstProg.ProId equals progDetail.ProId
        //                         join mstModel in _contextFac2.EtdMstModels.ToList()
        //                         on progDetail.MId equals mstModel.MId
        //                         select new { mstModel.MId, mstModel.MName };
        //            return Ok(result);
        //        }
        //    }
        //    else if (prams.fac == "3")
        //    {
        //        if (line == "Mecha line 6")
        //        {
        //            var context = _contextFac3Line6.EtdMstPrograms.ToList();
        //            if (proId != "")
        //            {
        //                context = context.Where(x => x.ProId.ToString() == proId).ToList();
        //            }
        //            var result = from mstProg in context
        //                         join progDetail in _contextFac3Line6.EtdProgramDetails.ToList()
        //                         on mstProg.ProId equals progDetail.ProId
        //                         join mstModel in _contextFac3Line6.EtdMstModels.ToList()
        //                         on progDetail.MId equals mstModel.MId
        //                         select new { mstModel.MId, mstModel.MName };
        //            return Ok(result);

        //        }
        //        else if (line == "Mecha line 8")
        //        {
        //            var context = _contextFac3Line8.McEtdMstPrograms.ToList();
        //            if (proId != "")
        //            {
        //                context = context.Where(x => x.ProId.ToString() == proId).ToList();
        //            }
        //            var result = from mstProg in context
        //                         join progDetail in _contextFac3Line8.McEtdProgramDetails.ToList()
        //                         on mstProg.ProId equals progDetail.ProId
        //                         join mstModel in _contextFac3Line8.McEtdMstModels.ToList()
        //                         on progDetail.MId equals mstModel.MId
        //                         select new { mstModel.MId, mstModel.MName };
        //            return Ok(result);
        //        }
        //        else {
        //            return BadRequest();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}


        [HttpPost]
        [Route("/filter/program")]
        public async Task<IActionResult> getFilterProgram(MOther prams)
        {
            string line = prams.line;
            if (prams.fac == "1")
            {
                return Ok(_contextFac1.EtdMstPrograms.ToList());
            }
            else if (prams.fac == "2")
            {
                if (line == "Mecha")
                {
                    return Ok(_contextFac2.EtdMstPrograms.ToList());
                }
                else
                {
                    return Ok(_contextFac2.McEtdMstPrograms.ToList());
                }
            }
            else if (prams.fac == "3")
            {
                if (line == "Mecha line 6")
                {
                    return Ok(_contextFac3Line6.EtdMstPrograms.ToList());
                }
                else if (line == "Mecha line 8")
                {
                    return Ok(_contextFac3Line8.McEtdMstPrograms.ToList());
                }
                else
                {
                    return BadRequest();
                }
                //return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/rank/{fac}")]
        public async Task<ActionResult> getRank(string fac)
        {
            if (fac == "1")
            {
                return Ok(_contextFac1.EtdGroupRanks.ToList().OrderBy(x=>x.RName));
            }else if (fac == "2")
            {
                return Ok(_contextFac1.EtdGroupRanks.ToList().OrderBy(x => x.RName));
            }
            else if (fac == "3")
            {
                return Ok(_contextFac3Line6.EtdGroupRanks.ToList().OrderBy(x => x.RName));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/model/edit/")]
        public async Task<ActionResult> editModel([FromBody] mModelEdit data)
        {
            string fac = data.Fac;
            string line = data.Line;
            if (fac == "1")
            {
                var context = _contextFac1.EtdModelDetails.Where(x => x.MId == data.MId && x.PId == data.PId && x.PtId == data.PtId).FirstOrDefault();
                if (context != null)
                {
                    context.PMidDimension = data.MidDimension;
                    context.PMinDimension = data.MinDimension;
                    context.PMaxDimension = data.MaxDimension;
                    context.RId = data.RId;
                    context.PDate = DateTime.Now;
                    var update = await _contextFac1.SaveChangesAsync();
                    return Ok(new { status = update });
                }
            }else if (fac == "2")
            {
                if (line == "Machine")
                {
                    var context = _contextFac2.McEtdModelDetails.Where(x => x.MId == data.MId && x.PId == data.PId && x.PtId == data.PtId).FirstOrDefault();
                    if (context != null)
                    {
                        context.PMidDimension = data.MidDimension;
                        context.PMinDimension = data.MinDimension;
                        context.PMaxDimension = data.MaxDimension;
                        context.RId = data.RId;
                        context.PDate = DateTime.Now;
                    }
                }
                else
                {
                    var context = _contextFac2.EtdModelDetails.Where(x => x.MId == data.MId && x.PId == data.PId && x.PtId == data.PtId).FirstOrDefault();
                    if (context != null)
                    {
                        context.PMidDimension = data.MidDimension;
                        context.PMinDimension = data.MinDimension;
                        context.PMaxDimension = data.MaxDimension;
                        context.RId = data.RId;
                        context.PDate = DateTime.Now;
                    }
                }
                var update = await _contextFac2.SaveChangesAsync();
                return Ok(new { status = update });
            }
            else if (fac == "3")
            {
                if (line == "Mecha line 8")
                {
                    var context = _contextFac3Line8.McEtdModelDetails.Where(x => x.MId == data.MId && x.PId == data.PId && x.PtId == data.PtId).FirstOrDefault();
                    if (context != null)
                    {
                        context.PMidDimension = data.MidDimension;
                        context.PMinDimension = data.MinDimension;
                        context.PMaxDimension = data.MaxDimension;
                        context.RId = data.RId;
                        context.PDate = DateTime.Now;
                    }
                    var update = await _contextFac3Line8.SaveChangesAsync();
                    return Ok(new { status = update });
                }
                else
                {
                    var context = _contextFac3Line6.EtdModelDetails.Where(x => x.MId == data.MId && x.PId == data.PId && x.PtId == data.PtId).FirstOrDefault();
                    if (context != null)
                    {
                        context.PMidDimension = data.MidDimension;
                        context.PMinDimension = data.MinDimension;
                        context.PMaxDimension = data.MaxDimension;
                        context.RId = data.RId;
                        context.PDate = DateTime.Now;
                    }
                    var update = await _contextFac3Line6.SaveChangesAsync();
                    return Ok(new { status = update });
                }
            }
            return Ok(new { mes = "ไม่พบข้อมูล", data = data, status = false });
        }

        [HttpPost]
        [Route("/model/delete/")]
        public async Task<ActionResult> deleteModel([FromBody] MModel data)
        {
            string fac = data.Fac;
            string line = data.Line;
            if (fac == "1")
            {
                var context = _contextFac1.EtdModelDetails.SingleOrDefault(x => x.MId == data.MId && x.PtId == data.ptId && x.PId == data.pId && x.RId == data.rId);
                if (context != null)
                {
                    context.PStatus = !context.PStatus;
                    _contextFac1.Update(context);
                    int eff = _contextFac1.SaveChanges();
                    return Ok(new { mes = eff });
                }
            }else if (fac == "2")
            {
                if (line  == "Machine")
                {
                    var context = _contextFac2.McEtdModelDetails.SingleOrDefault(x => x.MId == data.MId && x.PtId == data.ptId && x.PId == data.pId && x.RId == data.rId);
                    if (context != null)
                    {
                        context.PStatus = !context.PStatus;
                        _contextFac2.Update(context);
                        int eff = _contextFac2.SaveChanges();
                        return Ok(new { mes = eff });
                    }
                }
                else
                {
                    var context = _contextFac2.EtdModelDetails.SingleOrDefault(x => x.MId == data.MId && x.PtId == data.ptId && x.PId == data.pId && x.RId == data.rId);
                    if (context != null)
                    {
                        context.PStatus = !context.PStatus;
                        _contextFac2.Update(context);
                        int eff = _contextFac2.SaveChanges();
                        return Ok(new { mes = eff });
                    }
                }
            }else if (fac == "3")
            {
                if (line == "Mecha line 8")
                {
                    var context = _contextFac3Line8.McEtdModelDetails.SingleOrDefault(x => x.MId == data.MId && x.PtId == data.ptId && x.PId == data.pId && x.RId == data.rId);
                    if (context != null)
                    {
                        context.PStatus = !context.PStatus;
                        _contextFac3Line8.Update(context);
                        int eff = _contextFac3Line8.SaveChanges();
                        return Ok(new { mes = eff });
                    }
                }
                else
                {
                    var context = _contextFac3Line6.EtdModelDetails.SingleOrDefault(x => x.MId == data.MId && x.PtId == data.ptId && x.PId == data.pId && x.RId == data.rId);
                    if (context != null)
                    {
                        context.PStatus = !context.PStatus;
                        _contextFac3Line6.Update(context);
                        int eff = _contextFac3Line6.SaveChanges();
                        return Ok(new { mes = eff });
                    }
                }
            }

            return Ok(new { mes = false });
        }

        [HttpGet]
        [Route("/user/login/{id}")]
        public  async Task<ActionResult> login(string id)
        {
            var context = _contextDbHRM.Employees.SingleOrDefault(x => x.Code == id);
            return Ok(context);
        }
    }
}
