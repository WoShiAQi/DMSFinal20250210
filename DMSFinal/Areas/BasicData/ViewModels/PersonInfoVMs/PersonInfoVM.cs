using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.PersonInfoVMs
{
    public partial class PersonInfoVM : BaseCRUDVM<PersonInfo>
    {
        public List<ComboSelectListItem> AllTitleNamess { get; set; }
        [Display(Name = "职称")]
        public List<string> SelectedTitleNamesIDs { get; set; }

        public PersonInfoVM()
        {
            SetInclude(x => x.TitleNames);
            SetInclude(x => x.DeEvidence);
            SetInclude(x => x.TeaEvidence);
            SetInclude(x => x.PEvidence);
            SetInclude(x => x.SEvidence);
            SetInclude(x => x.TEvidence);
        }

        protected override void InitVM()
        {
            AllTitleNamess = DC.Set<TitleName>().GetSelectListItems(Wtm, y => y.TitleList);
            SelectedTitleNamesIDs = Entity.TitleNames?.Select(x => x.TitleNameId.ToString()).ToList();
            
        }

        public override void DoAdd()
        {
            Entity.TitleNames = new List<MidTitle>();
            if (SelectedTitleNamesIDs != null)
            {
                foreach (var id in SelectedTitleNamesIDs)
                {
                    MidTitle middle = new MidTitle();
                    middle.SetPropertyValue("TitleNameId", id);
                    Entity.TitleNames.Add(middle);
                }
            }
            Entity.Examine = CheckEnum.Checking;

            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            Entity.TitleNames = new List<MidTitle>();
            if(SelectedTitleNamesIDs != null )
            {
                 foreach (var item in SelectedTitleNamesIDs)
                {
                    MidTitle middle = new MidTitle();
                    middle.SetPropertyValue("TitleNameId", item);
                    Entity.TitleNames.Add(middle);
                }
            }

            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
