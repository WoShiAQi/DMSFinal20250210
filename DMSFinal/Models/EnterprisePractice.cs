using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace DMSFinal.Model.BasicData
{
    /// <summary>
    /// 下厂锻炼
    /// </summary>
	[Table("EnterprisePractices")]

    [Display(Name = "下厂锻炼")]
    public class EnterprisePractice : TopBasePoco
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
        [Display(Name = "企业名称")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public string CompanyName { get; set; }
        [Display(Name = "实践方式")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public PracticeEnum PracticalWay { get; set; }
        [Display(Name = "实践开始时间")]  
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "实践结束时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "企业联系人")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Contacts { get; set; }
        [Display(Name = "联系方式")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PhoneNumber { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<EnterprisePracticeEvidence> Evidence { get; set; }

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class EnterprisePracticeEvidence : TopBasePoco, ISubFile
    {
        public Guid EnterprisePracticeId { get; set; }
        public EnterprisePractice EnterprisePractice { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
