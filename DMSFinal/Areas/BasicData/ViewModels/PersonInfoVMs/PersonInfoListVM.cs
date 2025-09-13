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


namespace DMSFinal.BasicData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoListVM : BasePagedListVM<PersonInfo_View, PersonInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    this.MakeAction("PersonInfo","Edit","审核","审核",GridActionParameterTypesEnum.SingleIdWithNull,"BasicData",dialogWidth: 800).SetShowInRow(true),
                    //this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Edit, "审核", "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("PersonInfo", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<PersonInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<PersonInfo_View>>{
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.PersonID),
                this.MakeGridHeader(x => x.PoliticalID),
                this.MakeGridHeader(x => x.TitleList_view),
                this.MakeGridHeader(x => x.Diplomas),
                this.MakeGridHeader(x => x.Degree),
                this.MakeGridHeader(x => x.GraduateTime),
                this.MakeGridHeader(x => x.InWorkTime),
                this.MakeGridHeader(x => x.PartTimeJob),
                this.MakeGridHeader(x => x.IfDoubleTeacher),
                this.MakeGridHeader(x => x.IfDisciplineLeader),
                this.MakeGridHeader(x => x.Discipline),
                this.MakeGridHeader(x => x.Examine),
                this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PersonInfo_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<PersonInfo>()
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckContain(Searcher.PersonID, x => x.PersonID)
                .CheckEqual(Searcher.PoliticalID, x => x.PoliticalID)
                .CheckWhere(Searcher.SelectedTitleNamesIDs, x => DC.Set<MidTitle>().Where(y => Searcher.SelectedTitleNamesIDs.Contains(y.TitleNameId)).Select(z => z.PersonInfoId).Contains(x.ID))
                .CheckEqual(Searcher.Diplomas, x => x.Diplomas)
                .CheckEqual(Searcher.Degree, x => x.Degree)
                .CheckBetween(Searcher.GraduateTime?.GetStartTime(), Searcher.GraduateTime?.GetEndTime(), x => x.GraduateTime, includeMax: false)
                .CheckBetween(Searcher.InWorkTime?.GetStartTime(), Searcher.InWorkTime?.GetEndTime(), x => x.InWorkTime, includeMax: false)
                .CheckContain(Searcher.PartTimeJob, x => x.PartTimeJob)
                .CheckEqual(Searcher.IfDoubleTeacher, x => x.IfDoubleTeacher)
                .CheckEqual(Searcher.IfDisciplineLeader, x => x.IfDisciplineLeader)
                .CheckContain(Searcher.Discipline, x => x.Discipline)
                .Where(x => x.Examine == CheckEnum.Checking)
                .Select(x => new PersonInfo_View
                {
                    ID = x.ID,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    PersonID = x.PersonID,
                    PoliticalID = x.PoliticalID,
                    TitleList_view = x.TitleNames.Select(y => y.TitleName.TitleList).ToSepratedString(null, ","),
                    Diplomas = x.Diplomas,
                    Degree = x.Degree,
                    GraduateTime = x.GraduateTime,
                    InWorkTime = x.InWorkTime,
                    PartTimeJob = x.PartTimeJob,
                    IfDoubleTeacher = x.IfDoubleTeacher,
                    IfDisciplineLeader = x.IfDisciplineLeader,
                    Discipline = x.Discipline,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<PersonInfo>()
                    .CheckContain(Searcher.JobNo, x => x.JobNo)
                    .CheckContain(Searcher.Name, x => x.Name)
                    .CheckContain(Searcher.PersonID, x => x.PersonID)
                    .CheckEqual(Searcher.PoliticalID, x => x.PoliticalID)
                    .CheckWhere(Searcher.SelectedTitleNamesIDs, x => DC.Set<MidTitle>().Where(y => Searcher.SelectedTitleNamesIDs.Contains(y.TitleNameId)).Select(z => z.PersonInfoId).Contains(x.ID))
                    .CheckEqual(Searcher.Diplomas, x => x.Diplomas)
                    .CheckEqual(Searcher.Degree, x => x.Degree)
                    .CheckBetween(Searcher.GraduateTime?.GetStartTime(), Searcher.GraduateTime?.GetEndTime(), x => x.GraduateTime, includeMax: false)
                    .CheckBetween(Searcher.InWorkTime?.GetStartTime(), Searcher.InWorkTime?.GetEndTime(), x => x.InWorkTime, includeMax: false)
                    .CheckContain(Searcher.PartTimeJob, x => x.PartTimeJob)
                    .CheckEqual(Searcher.IfDoubleTeacher, x => x.IfDoubleTeacher)
                    .CheckEqual(Searcher.IfDisciplineLeader, x => x.IfDisciplineLeader)
                    .CheckContain(Searcher.Discipline, x => x.Discipline)
                    .Where(x => x.JobNo == LoginUserInfo.ITCode)
                    .Where(x => x.Examine != CheckEnum.Pass)
                    .Select(x => new PersonInfo_View
                    {
                        ID = x.ID,
                        JobNo = x.JobNo,
                        Name = x.Name,
                        PersonID = x.PersonID,
                        PoliticalID = x.PoliticalID,
                        TitleList_view = x.TitleNames.Select(y => y.TitleName.TitleList).ToSepratedString(null, ","),
                        Diplomas = x.Diplomas,
                        Degree = x.Degree,
                        GraduateTime = x.GraduateTime,
                        InWorkTime = x.InWorkTime,
                        PartTimeJob = x.PartTimeJob,
                        IfDoubleTeacher = x.IfDoubleTeacher,
                        IfDisciplineLeader = x.IfDisciplineLeader,
                        Discipline = x.Discipline,
                        Examine = x.Examine,
                        Reason = x.Reason,
                    })
                    .OrderBy(x => x.ID);
                return query;

            }
                
        }

    }

    public class PersonInfo_View : PersonInfo{
        [Display(Name = "职称")]
        public String TitleList_view { get; set; }

    }
}
