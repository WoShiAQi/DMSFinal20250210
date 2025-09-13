using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DMSFinal.Model.BasicData;


namespace DMSFinal.BasicData.ViewModels.TitleNameVMs
{
    public partial class TitleNameListVM : BasePagedListVM<TitleName_View, TitleNameSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                this.MakeStandardAction("TitleName", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
            };
        }


        protected override IEnumerable<IGridColumn<TitleName_View>> InitGridHeader()
        {
            return new List<GridColumn<TitleName_View>>{
                this.MakeGridHeader(x => x.TitleList),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TitleName_View> GetSearchQuery()
        {
            var query = DC.Set<TitleName>()
                .Select(x => new TitleName_View
                {
				    ID = x.ID,
                    TitleList = x.TitleList,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TitleName_View : TitleName{

    }
}
