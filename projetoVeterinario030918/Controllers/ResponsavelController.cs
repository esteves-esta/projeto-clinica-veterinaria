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
    public class ResponsavelController : Controller
    {


        // GET: Responsavel
        public ActionResult cadastro()
        {
            return View();
        }

        public ActionResult confirma(FormCollection frm)
        {
            responsavelDTO dto = new responsavelDTO();
            responsavelBLL bll = new responsavelBLL();

            dto.codResp = frm["txtCod"];
            dto.nome = frm["txtNome"];
            dto.end = frm["txtEnd"];
            dto.bairro = frm["txtBairro"];
            dto.cidade = frm["txtCid"];
            dto.uf = frm["txtUf"];

            bll.inserirResp(dto);

            return View();
        }

        public ActionResult consulta()
        {
            responsavelBLL bll = new responsavelBLL();

            GridView dgv = new GridView(); //mesma coisa do datagridview do windowsfrom
            dgv.DataSource = bll.consultaResp();
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

        public ActionResult resultado(FormCollection frm){

            responsavelDTO dto = new responsavelDTO();
            responsavelBLL bll = new responsavelBLL();

            GridView dgv = new GridView();

            dto.nome = frm["txtNome"];

            dgv.DataSource = bll.buscaResp(dto); //puxa o metodo de pesquisa e usa o termo inserido pelo usuario
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }

    }
}