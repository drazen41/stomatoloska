﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stomatoloska.BLL;

namespace Stomatoloska.Webforms
{
    public partial class frmNarucivanje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calNarucivanje_SelectionChanged(object sender, EventArgs e)
        {
            if (calNarucivanje.SelectedDates.Count > 0)
            {
                pnlTjedni.Visible = true;
                pnlDnevni.Visible = false;
                PrikaziRezerviraneTermine();
            }
            else
            {
                pnlTjedni.Visible = false;
                pnlDnevni.Visible = true;
            }
        }

        private void PrikaziRezerviraneTermine()
        {
            
            
            
        }
    }
}