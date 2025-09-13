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

namespace DMSFinal.BasicData.ViewModels.PaperVMs
{
    public partial class PaperBatchVM : BaseBatchVM<Paper, Paper_BatchEdit>
    {
        public PaperListVM PaListVM { get; set; }
        public PaperBatchVM()
        {
            ListVM = new PaperListVM();
            LinkedVM = new Paper_BatchEdit();
        }
        protected override void InitVM()
        {
            PaListVM = Wtm.CreateVM<PaperListVM>();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<Paper>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedPaCodes != null)
                {
                    foreach (var rolecode in LinkedVM.SelectedPaCodes)
                    {
                        Paper r = new Paper
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
    public class Paper_BatchEdit : BaseVM
    {
        [Display(Name = "部门")]
        public DepartmentEnum? Department { get; set; }
        [Display(Name = "工号")]
        public String JobNo { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "职称1")]
        public TitleEnum? Title1 { get; set; }
        [Display(Name = "职称2")]
        public TitleEnum2? Title2 { get; set; }
        [Display(Name = "论文名称")]
        public String PaperTitle { get; set; }
        [Display(Name = "刊物名称")]
        public String MagazineName { get; set; }
        [Display(Name = "出版时间")]
        public DateTime? PublicTime { get; set; }
        [Display(Name = "年卷期页")]
        public String Info { get; set; }
        [Display(Name = "期刊类别")]
        public CategoryEnum? Category { get; set; }
        [Display(Name = "是否国际索引SCI")]
        public IfEnum? IsSCI { get; set; }
        [Display(Name = "SCI索引号")]
        public String SCINo { get; set; }
        [Display(Name = "是否国际索引EI")]
        public CategoryEnum? IsEI { get; set; }
        [Display(Name = "EI索引号")]
        public String EINo { get; set; }
        [Display(Name = "是否国际索引ISTP")]
        public IfEnum? IsISTP { get; set; }
        [Display(Name = "ISTP索引号")]
        public String ISTPNo { get; set; }
        [Display(Name = "他引次数")]
        public Int32? Num { get; set; }
        [Display(Name = "影响因子")]
        public Single? ImpactFactor { get; set; }
        [Display(Name = "第几作者")]
        public RankEnum? Rank { get; set; }
        [Display(Name = "文章第一作者是否本校教师")]
        public IfEnum? IsOurSchool { get; set; }
        [Display(Name = "审核")]
        public CheckEnum? Examine { get; set; }
        [Display(Name = "不通过原因")]
        public String Reason { get; set; }
        public List<string> SelectedPaCodes { get; set; }
        public List<ComboSelectListItem> AllPas { get; set; }


        protected override void InitVM()
        {
            AllPas = DC.Set<Paper>().GetSelectListItems(Wtm, y => y.Name, y => y.JobNo);
        }

    }

}
