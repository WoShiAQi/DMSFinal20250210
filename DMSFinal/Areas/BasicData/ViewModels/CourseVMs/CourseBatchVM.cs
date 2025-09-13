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

namespace DMSFinal.BasicData.ViewModels.CourseVMs
{
    public partial class CourseBatchVM : BaseBatchVM<Course, Course_BatchEdit>
    {
        public CourseListVM CouListVM { get; set; }
        public CourseBatchVM()
        {
            ListVM = new CourseListVM();
            LinkedVM = new Course_BatchEdit();
        }
        protected override void InitVM()
        {
            CouListVM = Wtm.CreateVM<CourseListVM>();
        }
        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<Course>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedCouCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedCouCodes)
                    {
                        Course r = new Course
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
    public class Course_BatchEdit : BaseVM
    {
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }

        public List<string> SelectedCouCodes { get; set; }
        public List<ComboSelectListItem> AllCourses { get; set; }


        protected override void InitVM()
        {
            AllCourses = DC.Set<Course>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
