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
    public class TipoAnimalController : Controller
    {
        // GET: TipoAnimal
        public ActionResult cadastro()
        {
            return View();
        }

        public ActionResult confirma(FormCollection frm)
        {
            tipoAnimalDTO dto = new tipoAnimalDTO();
            tipoAnimalBLL bll = new tipoAnimalBLL();

            dto.codTipo = frm["txtCod"];
            dto.tipo = frm["txtTipo"];

            bll.inserirTipo(dto);

            return View();
        }

        public ActionResult consulta()
        {
            tipoAnimalBLL bll = new tipoAnimalBLL();

            GridView dgv = new GridView(); //mesma coisa do datagridview do windowsfrom
            dgv.DataSource = bll.consultaTipo();
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

            tipoAnimalDTO dto = new tipoAnimalDTO();
            tipoAnimalBLL bll = new tipoAnimalBLL();

            GridView dgv = new GridView();

            dto.codTipo = frm["txtCod"];

            dgv.DataSource = bll.buscaTipo(dto); //puxa o metodo de pesquisa e usa o termo inserido pelo usuario
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }

    }
}