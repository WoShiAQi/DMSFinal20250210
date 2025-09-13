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
    /// 论文
    /// </summary>
	[Table("Papers")]

    [Display(Name = "论文")]
    public class Paper : TopBasePoco
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

        [Display(Name = "论文名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PaperTitle { get; set; }
        [Display(Name = "刊物名称")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string MagazineName { get; set; }
        [Display(Name = "出版时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? PublicTime { get; set; }
        [Display(Name = "年卷期页")]
        [StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]       
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Info { get; set; }
        [Display(Name = "期刊类别")] 
        [Required(ErrorMessage = "Validate.{0}required")]
        public CategoryEnum Category { get; set; }
        [Display(Name = "是否国际索引SCI")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IsSCI { get; set; }
        [Display(Name = "SCI索引号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string SCINo { get; set; }
        [Display(Name = "是否国际索引EI")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CategoryEnum IsEI { get; set; }
        [Display(Name = "EI索引号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string EINo { get; set; }
        [Display(Name = "是否国际索引ISTP")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IsISTP { get; set; }
        [Display(Name = "ISTP索引号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string ISTPNo { get; set; }
        [Display(Name = "他引次数")]      
        [Range(0,999999999,ErrorMessage="Validate.{0}range{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? Num { get; set; }
        [Display(Name = "影响因子")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public float? ImpactFactor { get; set; }
        [Display(Name = "第几作者")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "文章第一作者是否本校教师")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IsOurSchool { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<PaperEvidence> Evidence { get; set; }

        [Display(Name = "审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class PaperEvidence : TopBasePoco, ISubFile
    {
        public Guid PaperId { get; set; }
        public Paper Paper { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
