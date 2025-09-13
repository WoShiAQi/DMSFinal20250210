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
    /// 专利软著
    /// </summary>
	[Table("PatentSoftnesss")]

    [Display(Name = "专利软著")]
    public class PatentSoftness : TopBasePoco
    {
        [Display(Name = "部门")]
        //[Comment("部门")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("姓名")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "职称1")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum Title1 { get; set; }

        [Display(Name = "职称2")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum2 Title2 { get; set; }

        [Display(Name = "名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("名称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Topic { get; set; }
        [Display(Name = "类别")]
        //[Comment("类别")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public PatentEnum PatentCategory { get; set; }
        [Display(Name = "授权时间")]
        //[Comment("授权时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? AuthorizedDate { get; set; }
        [Display(Name = "专利号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("专利号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PatentNumber { get; set; }
        [Display(Name = "申请时间")]
        //[Comment("申请时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? ApplicationTime { get; set; }
        [Display(Name = "授权公告号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("申请号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string ApplicationNumber { get; set; }
        [Display(Name = "是否职务发明")]
        //[Comment("是否职务发明")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfEmployee { get; set; }
        [Display(Name = "第几作者")]
        //[Comment("第几作者")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "专利第一作者是否本校教师")]
        //[Comment("专利第一作者是否本校教师")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IsOurSchool { get; set; }
        [Display(Name = "佐证材料扫描件")]
        //[Comment("佐证材料扫描件")]
        public List<PatentSoftnessEvidence> Evidence { get; set; }
        [Display(Name = "计划维持有效时间（年）")]
        //[Comment("计划维持有效时间（年）")]
        [Range(0,999999999,ErrorMessage="Validate.{0}range{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? HoldTime { get; set; }
        [Display(Name = "工号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("工号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "审核")]
        //[Comment("审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        //[Comment("不通过原因")]
        public string Reason { get; set; }

	}
    public class PatentSoftnessEvidence : TopBasePoco, ISubFile
    {
        public Guid PatentSoftnessId { get; set; }
        public PatentSoftness PatentSoftness { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
