using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.ApprovedData.ViewModels.AchievementTransformationVMs
{
    public partial class AchievementTransformationListVM : BasePagedListVM<AchievementTransformation_View, AchievementTransformationSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("AchievementTransformation", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<AchievementTransformation_View>> InitGridHeader()
        {
            return new List<GridColumn<AchievementTransformation_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.SubjectName),
                this.MakeGridHeader(x => x.CompanyName),
                this.MakeGridHeader(x => x.Funds),
                this.MakeGridHeader(x => x.StartTime),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeader(x => x.Participants),
                //this.MakeGridHeader(x => x.Evidence).SetFormat(EvidenceFormat),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        //private List<ColumnFormatInfo> EvidenceFormat(AchievementTransformation_View entity, object val)
        //{
        //    var temp = DC.Set<AchievementTransformationEvidence>()
        //              .Where(x => x.AchievementTransformationId == entity.ID)
        //              .Select(x => new AchievementTransformationEvidence_View
        //              {
        //                  FileId = x.FileId,
        //              }).ToList();
        //    foreach (var id in temp) {
        //        return new List<ColumnFormatInfo>
        //        {
        //            ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,id),
        //            ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,id,640,480),
        //        };
        //    }
           
        //}
        public override IOrderedQueryable<AchievementTransformation_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<AchievementTransformation>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.SubjectName, x => x.SubjectName)
                .CheckContain(Searcher.CompanyName, x => x.CompanyName)
                .CheckEqual(Searcher.Funds, x => x.Funds)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.Participants, x => x.Participants)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new AchievementTransformation_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    SubjectName = x.SubjectName,
                    CompanyName = x.CompanyName,
                    Funds = x.Funds,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Participants = x.Participants,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<AchievementTransformation>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.SubjectName, x => x.SubjectName)
                .CheckContain(Searcher.CompanyName, x => x.CompanyName)
                .CheckEqual(Searcher.Funds, x => x.Funds)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.Participants, x => x.Participants)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new AchievementTransformation_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    SubjectName = x.SubjectName,
                    CompanyName = x.CompanyName,
                    Funds = x.Funds,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Participants = x.Participants,
                })
                .OrderBy(x => x.ID);                
                return query;
            }
                
        }

    }

    public class AchievementTransformation_View : AchievementTransformation{

    }
    public class AchievementTransformationEvidence_View : AchievementTransformationEvidence
{

    }
}
