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
    /// 个人信息
    /// </summary>
	[Table("PersonInfos")]

    [Display(Name = "个人信息")]
    public class PersonInfo : TopBasePoco
    {
        [Display(Name = "工号")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public string JobNo { get; set; }

        [Display(Name = "姓名")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name = "身份证号")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PersonID { get; set; }

        [Display(Name = "政治身份")]       
        [Required(ErrorMessage = "Validate.{0}required")]
        public PoliticalIDEnum PoliticalID { get; set; }        

        [Display(Name = "职称")]        
        public List<MidTitle> TitleNames { get; set; }

        [Display(Name = "学历")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public DiplomasEnum Diplomas { get; set; }

        [Display(Name = "学位")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public DegreeEnum Degree { get; set; }
        
        [Display(Name = "毕业时间")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime GraduateTime { get; set; }

        [Display(Name = "参加工作时间")]        
        [Required(ErrorMessage = "Validate.{0}required")]
        public DateTime InWorkTime { get; set; }

        [Display(Name = "社会兼职")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PartTimeJob { get; set; }

        [Display(Name = "是否双师")]
        //[Comment("第一是否本校老师")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfDoubleTeacher { get; set; }

        [Display(Name = "是否专业带头人")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public IfEnum IfDisciplineLeader { get; set; }

        [Display(Name = "所学专业")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string Discipline { get; set; }

        [Display(Name = "社会兼职扫描件")]
        //[Comment("社会兼职扫描件")]
        public List<PartTimeJobEvidence> PEvidence { get; set; }

        [Display(Name = "学历学位证书扫描件")]
        //[Comment("社会兼职扫描件")]
        public List<DegreeEvidence> DeEvidence { get; set; }

        [Display(Name = "职称证书扫描件")]
        //[Comment("社会兼职扫描件")]
        public List<TitleEvidence> TEvidence { get; set; }

        [Display(Name = "教师资格证扫描件")]
        //[Comment("社会兼职扫描件")]
        public List<TeacherEvidence> TeaEvidence { get; set; }

        [Display(Name = "职业技能等级证书扫描件")]
        //[Comment("社会兼职扫描件")]
        public List<SkillEvidence> SEvidence { get; set; }


        [Display(Name = "审核")]
        //[Comment("审核")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public CheckEnum Examine { get; set; }
        [Display(Name = "不通过原因")]
        //[Comment("不通过原因")]
        public string Reason { get; set; }

	}
    public class PartTimeJobEvidence : TopBasePoco, ISubFile
    {
        public Guid PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class DegreeEvidence : TopBasePoco, ISubFile
    {
        public Guid PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class TitleEvidence : TopBasePoco, ISubFile
    {
        public Guid PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class TeacherEvidence : TopBasePoco, ISubFile
    {
        public Guid PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class SkillEvidence : TopBasePoco, ISubFile
    {
        public Guid PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
