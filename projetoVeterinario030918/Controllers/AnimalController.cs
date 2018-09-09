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
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult cadastro()
        {
            return View();
        }

        public ActionResult confirma(FormCollection frm)
        {
            animalBLL bll = new animalBLL();
            animalDTO dto = new animalDTO();

            dto.codAnimal = frm["txtCod"];
            dto.nomeAnimal = frm["txtNome"];
            dto.codTipo = frm["txtCodTP"];
            dto.codRaca = frm["txtCodRA"];
            dto.codResp = frm["txtCodR"];
            dto.dataCadastro = frm["txtData"];

            bll.inserirAnimal(dto);

            return View();
        }

        public ActionResult consulta()
        {
            animalBLL bll = new animalBLL();

            GridView dgv = new GridView(); //mesma coisa do datagridview do windowsfrom
            dgv.DataSource = bll.consultaAnimal();
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


        public ActionResult pesquisas()
        {
            return View();
        }

        public ActionResult resultado(FormCollection frm)
        {

            animalBLL bll = new animalBLL();
            animalDTO dto = new animalDTO();

            GridView dgv = new GridView();

            dto.nomeAnimal = frm["txtNome"];

            dgv.DataSource = bll.buscaAnimal(dto); //puxa o metodo de pesquisa e usa o termo inserido pelo usuario
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();

            return View();
        }

    }
}