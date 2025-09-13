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
    /// 横向课题
    /// </summary>
	[Table("HorizontalSubjects")]

    [Display(Name = "横向课题")]
    public class HorizontalSubject : TopBasePoco
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

        [Display(Name = "横向课题名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string SubjectName { get; set; }
        [Display(Name = "合作公司全称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string CompanyName { get; set; }
        [Display(Name = "研究经费（元）")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? Funds { get; set; }
        [Display(Name = "签订合同时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "项目完成时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "参与人员")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Participants { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<HorizontalSubjectEvidence> Evidence { get; set; }
        [Display(Name = "合同扫描件")]
        public List<HorizontalSubjectContract> Contract { get; set; }
        [Display(Name = "结题材料扫描件")]
        public List<HorizontalSubjectClosingMaterials> ClosingMaterials { get; set; }
       
        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class HorizontalSubjectEvidence : TopBasePoco, ISubFile
    {
        public Guid HorizontalSubjectId { get; set; }
        public HorizontalSubject HorizontalSubjects { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class HorizontalSubjectContract : TopBasePoco, ISubFile
    {
        public Guid HorizontalSubjectId { get; set; }
        public HorizontalSubject HorizontalSubjects { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class HorizontalSubjectClosingMaterials : TopBasePoco, ISubFile
    {
        public Guid HorizontalSubjectId { get; set; }
        public HorizontalSubject HorizontalSubjects { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
