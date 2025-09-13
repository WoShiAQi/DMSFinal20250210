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


namespace DMSFinal.ApprovedData.ViewModels.TrainingVMs
{
    public partial class TrainingListVM : BasePagedListVM<Training_View, TrainingSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Training", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Training", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<Training_View>> InitGridHeader()
        {
            return new List<GridColumn<Training_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.TrainName),
                this.MakeGridHeader(x => x.TeachingTime),
                this.MakeGridHeader(x => x.StartTime),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeader(x => x.TrainingUnit),
                //this.MakeGridHeader(x => x.Examin),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Training_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<Training>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.TrainName, x => x.TrainName)
                .CheckEqual(Searcher.TeachingTime, x => x.TeachingTime)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.TrainingUnit, x => x.TrainingUnit)
                .CheckEqual(Searcher.Examin, x => x.Examin)
                .Where(x => x.Examin == CheckEnum.Pass)
                .Select(x => new Training_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    TrainName = x.TrainName,
                    TeachingTime = x.TeachingTime,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    TrainingUnit = x.TrainingUnit,                    
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<Training>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.TrainName, x => x.TrainName)
                .CheckEqual(Searcher.TeachingTime, x => x.TeachingTime)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.TrainingUnit, x => x.TrainingUnit)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examin == CheckEnum.Pass)
                .Select(x => new Training_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    TrainName = x.TrainName,
                    TeachingTime = x.TeachingTime,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    TrainingUnit = x.TrainingUnit,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class Training_View : Training{

    }
}
