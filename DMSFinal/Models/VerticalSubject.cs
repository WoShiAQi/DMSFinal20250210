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
	[Table("VerticalSubjects")]

    [Display(Name = "纵向科研")]
    public class VerticalSubject : TopBasePoco
    {
        [Display(Name = "部门")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public DepartmentEnum Department { get; set; }
        [Display(Name = "工号")]
        //[StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }
        [Display(Name = "姓名")]
        //[StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "职称1")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum Title1 { get; set; }

        [Display(Name = "职称2")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public TitleEnum2 Title2 { get; set; }

        [Display(Name = "课题名称")]
        //[StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string SubjectName { get; set; }
        [Display(Name = "课题等级")]
        //[StringLength(80, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public SubjectEnum SubjectLevel { get; set; }
        [Display(Name = "课题来源")]
        //[StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string SubjectSource { get; set; }
        [Display(Name = "课题编号")]
        //[StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public string SubjectNo { get; set; }
        [Display(Name = "经费(元)")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public int? Funds { get; set; }
        [Display(Name = "立项时间")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "是否结项")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfCose { get; set; }
        [Display(Name = "结项时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "排名")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public RankEnum Rank { get; set; }
        [Display(Name = "主持人是否本校")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfOurSchool { get; set; }
        [Display(Name = "佐证材料扫描件")]
        public List<VerticalSubjectEvidence> Evidence { get; set; }
        [Display(Name = "立项下达红头文件或立项通知")]
        public List<VerticalSubjectApprovalDoc> ApprovalDoc { get; set; }
        [Display(Name = "验收证书及验定证书")]
        public List<VerticalSubjectAccCerti> AccCerti { get; set; }

        [Display(Name = "审核")]
        //[Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        public string Reason { get; set; }

	}
    public class VerticalSubjectEvidence : TopBasePoco, ISubFile
    {
        public Guid VerticalSubjectId { get; set; }
        public VerticalSubject VerticalSubject { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class VerticalSubjectApprovalDoc : TopBasePoco, ISubFile
    {
        public Guid VerticalSubjectId { get; set; }
        public VerticalSubject VerticalSubject { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class VerticalSubjectAccCerti : TopBasePoco, ISubFile
    {
        public Guid VerticalSubjectId { get; set; }
        public VerticalSubject VerticalSubject { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
