using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace DMSFinal.BasicData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoBatchVM : BaseBatchVM<PersonInfo, PersonInfo_BatchEdit>
    {
        public PersonInfoListVM PerListVM { get; set; }
        public PersonInfoBatchVM()
        {
            ListVM = new PersonInfoListVM();
            LinkedVM = new PersonInfo_BatchEdit();
        }
        protected override void InitVM()
        {
            PerListVM = Wtm.CreateVM<PersonInfoListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<PersonInfo>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedPerCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedPerCodes)
                    {
                        PersonInfo r = new PersonInfo
                        {
                            Checked = entity.Checked
                        };
                        DC.AddEntity(r);
                    }
                }
            }
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class PersonInfo_BatchEdit : BaseVM
    {
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        public List<string> SelectedPerCodes { get; set; }
        public List<ComboSelectListItem> AllPers { get; set; }


        protected override void InitVM()
        {
            AllPers = DC.Set<PersonInfo>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
