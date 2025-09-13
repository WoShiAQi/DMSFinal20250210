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


namespace DMSFinal.BasicData.ViewModels.RewardsVMs
{
    public partial class RewardsListVM : BasePagedListVM<Rewards_View, RewardsSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    this.MakeAction("Rewards","Edit","审核","审核",GridActionParameterTypesEnum.SingleIdWithNull,"BasicData",dialogWidth: 800).SetShowInRow(true),
                    //this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("Rewards", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<Rewards_View>> InitGridHeader()
        {
            return new List<GridColumn<Rewards_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.Topic),
                this.MakeGridHeader(x => x.RewardName),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.AwardLevel),
                this.MakeGridHeader(x => x.RewardTime),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IfOurSchool),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Examine),
                this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Rewards_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<Rewards>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckContain(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                //.CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.Examine == CheckEnum.Checking)
                .Select(x => new Rewards_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    JobNo = x.JobNo,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<Rewards>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckContain(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                //.CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine != CheckEnum.Pass)
                .Select(x => new Rewards_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    JobNo = x.JobNo,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class Rewards_View : Rewards{

    }
}
