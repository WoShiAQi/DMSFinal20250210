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
    /// 著作统计
    /// </summary>
	[Table("Publicationss")]

    [Display(Name = "_Model.Publications")]
    public class Publications : TopBasePoco
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

        [Display(Name = "著作形式")]
        //[Comment("著作形式")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public PublicationEnum PublicationForm { get; set; }
        [Display(Name = "著作名称")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("著作名称")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PublicationName { get; set; }
        [Display(Name = "出版社")]
        [StringLength(60, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("出版社")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Press { get; set; }
        [Display(Name = "出版时间")]
        //[Comment("出版时间")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? PublicationTime { get; set; }
        [Display(Name = "撰写字数（万）")]
        //[Comment("撰写字数（万）")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public float? WriteWordCount { get; set; }
        [Display(Name = "书号")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Comment("书号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string BookNo { get; set; }
        [Display(Name = "排名")]
        //[Comment("排名")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "第一主编是否本校")]
        //[Comment("第一主编是否本校")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IsOurSchool { get; set; }
        [Display(Name = "佐证材料扫描件")]
        //[Comment("佐证材料扫描件")]
        public List<PublicationsEvidence> Evidence { get; set; }
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
    public class PublicationsEvidence : TopBasePoco, ISubFile
    {
        public Guid PublicationsId { get; set; }
        public Publications Publications { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
