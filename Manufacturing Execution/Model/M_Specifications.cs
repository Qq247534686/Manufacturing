using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 规格书类
    /// </summary>
    public class M_Specifications
    {
        public string specificationsName { get; set; }
        public string clientCode { get; set; }
        public string productModel { get; set; }
        public string productCode { get; set; }
        public int LD_Method { get; set; }
        public string LD_Po { get; set; }
        public int LD_Wavelength { get; set; }
        public string LD_If { get; set; }
        public int temperature { get; set; }
        public string temperatureText { get; set; }
        public int PT_Method { get; set; }
        public int PT_apt { get; set; }
        public int PT_code { get; set; }
        public string PT_time { get; set; }
        public string PT_Sem { get; set; }
        public int PT_error { get; set; }
        public int PT_speed { get; set; }
        public int PT_Wavelength { get; set; }
        public int PT_APDV { get; set; }

        public string pomin { get; set; }
        public string pominText { get; set; }
        public string ithmin { get; set; }
        public string vfmin { get; set; }
        public string imomin { get; set; }
        public string imominText { get; set; }
        public string esmin { get; set; }
        public string esminText { get; set; }
        public string rsmin { get; set; }
        public string pkinkmin { get; set; }
        public string kimomin { get; set; }
        public string cmmin { get; set; }
        public string themin { get; set; }
        public string sRMSmin { get; set; }
        public string tEmin { get; set; }
        public string imoKinkmin { get; set; }
        public string idarkmin { get; set; }
        public string ifmin { get; set; }
        public string handlePomin { get; set; }
        public string handlePominText { get; set; }
        public string parallelmin { get; set; }

        public string pomax { get; set; }
        public string pomaxText { get; set; }
        public string ithmax { get; set; }
        public string vfmax { get; set; }
        public string imomax { get; set; }
        public string imomaxText { get; set; }
        public string esmax { get; set; }
        public string esmaxText { get; set; }
        public string rsmax { get; set; }
        public string pkinkmax { get; set; }
        public string kimomax { get; set; }
        public string cmmax { get; set; }
        public string themax { get; set; }
        public string sRMSmax { get; set; }
        public string tEmax { get; set; }
        public string imoKinkmax { get; set; }
        public string idarkmax { get; set; }
        public string ifmax { get; set; }
        public string handlePomax { get; set; }
        public string handlePomaxText { get; set; }
        public string parallelmax { get; set; }

        public string vbrmin { get; set; }
        public string iopmin { get; set; }
        public string iopminText { get; set; }
        public string iomin { get; set; }
        public string iominText { get; set; }
        public string idpmin { get; set; }
        public string iccmin { get; set; }
        public string senmin { get; set; }

        public string vbrmax { get; set; }
        public string iopmax { get; set; }
        public string iomax { get; set; }
        public string idpmax { get; set; }
        public string iccmax { get; set; }
        public string senmax { get; set; }
        public string senmaxText { get; set; }

        public string remarks { get; set; }
        public DateTime createTime { get; set; }
        public int joinID { get; set; }
    }
}
