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

namespace DMSFinal.BasicData.ViewModels.JiaoYanVMs
{
    public partial class JiaoYanBatchVM : BaseBatchVM<JiaoYan, JiaoYan_BatchEdit>
    {
        public JiaoYanListVM JYListVM { get; set; }
        public JiaoYanBatchVM()
        {
            ListVM = new JiaoYanListVM();
            LinkedVM = new JiaoYan_BatchEdit();
        }
        protected override void InitVM()
        {
            JYListVM = Wtm.CreateVM<JiaoYanListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<JiaoYan>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedJYCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedJYCodes)
                    {
                        JiaoYan r = new JiaoYan
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
    public class JiaoYan_BatchEdit : BaseVM
    {
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "职称1")]
        public TitleEnum? Title1 { get; set; }
        [Display(Name = "职称2")]
        public TitleEnum2? Title2 { get; set; }
        [Display(Name = "课题名称")]
        public String SubjectName { get; set; }
        [Display(Name = "课题等级")]
        public SubjectEnum? SubjectLevel { get; set; }
        [Display(Name = "课题来源")]
        public String SubjectSource { get; set; }
        [Display(Name = "课题编号")]
        public String SubjectNo { get; set; }
        [Display(Name = "立项时间")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "是否结项")]
        public IfEnum? IfClose { get; set; }
        [Display(Name = "排名")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "主持人是否本校")]
        public IfEnum? IfOurSchool { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        public List<string> SelectedJYCodes { get; set; }
        public List<ComboSelectListItem> AllJYs { get; set; }


        protected override void InitVM()
        {
            AllJYs = DC.Set<JiaoYan>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
