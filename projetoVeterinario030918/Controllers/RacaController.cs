using projetoVeterinario030918.Dados.BLL;
using projetoVeterinario030918.Dados.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoVeterinario030918.Controllers
{
    [HandleError]
    public class RacaController : Controller
    {
        // GET: Raca
        public ActionResult cadastro()
        {
            return View();
        }

        public ActionResult confirma(FormCollection frm)
        {
            racaBLL bll = new racaBLL();
            racaDTO dto = new racaDTO();

            dto.codRaca = frm["txtCod"];
            dto.raca = frm["txtRaca"];

            bll.inserirRaca(dto);
            return View();
        }

        public ActionResult consulta()
        {
            racaBLL bll = new racaBLL();

            GridView dgv = new GridView(); //mesma coisa do datagridview do windowsfrom
            dgv.DataSource = bll.consultaRaca();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();


            return View();
        }

        public ActionResult pesquisa()
        {
            return View();
        }


        public ActionResult resultado(FormCollection frm)
        {

            racaBLL bll = new racaBLL();
            racaDTO dto = new racaDTO();

            GridView dgv = new GridView();

            dto.raca = frm["txtRaca"];

            dgv.DataSource = bll.buscaRaca(dto); //puxa o metodo de pesquisa e usa o termo inserido pelo usuario
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }
    }
}