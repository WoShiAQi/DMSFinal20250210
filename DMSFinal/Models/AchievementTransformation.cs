using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
using System.Text.Json.Serialization;
using DMSFinal.Model;

namespace DMSFinal.Model.BasicData
{
    /// <summary>
    /// 纵向科研
    /// </summary>
	[Table("AchievementTransformations")]

    [Display(Name = "纵向科研")]
    public class AchievementTransformation : TopBasePoco
    {
        [Display(Name = "部门")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "工号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "职称1")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum Title1 { get; set; }

        [Display(Name = "职称2")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum2 Title2 { get; set; }

        [Display(Name = "成果转化名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string SubjectName { get; set; }

        [Display(Name = "合作企业全称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string CompanyName { get; set; }

        
        [Display(Name = "经费(元)")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? Funds { get; set; }
        [Display(Name = "签订时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? StartTime { get; set; }
        
        [Display(Name = "项目完成时间")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "参与人员")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Participants { get; set; }

        [Display(Name = "到款证明扫描件")]
        public List<AchievementTransformationEvidence> Evidence { get; set; }
        [Display(Name = "合同扫描件")]
        public List<AchievementTransformationApprovalDoc> ApprovalDoc { get; set; }
        

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class AchievementTransformationEvidence : TopBasePoco, ISubFile
    {
        public Guid AchievementTransformationId { get; set; }
        public AchievementTransformation AchievementTransformation { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class AchievementTransformationApprovalDoc : TopBasePoco, ISubFile
    {
        public Guid AchievementTransformationId { get; set; }
        public AchievementTransformation AchievementTransformation { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }  

}
