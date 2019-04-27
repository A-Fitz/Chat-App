using ChatApp;
using ChatApp.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Mock_UI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mock_UI
{
   public partial class CreateChatroomForm : MaterialForm
   {
      private readonly IServerConnection serverConnection;
      private readonly IMessageService messageService;
      private MaterialSkinManager materialSkinManager;

      public CreateChatroomForm(IServerConnection serverConnection, IMessageService messageService)
      {
         this.serverConnection = serverConnection;
         this.messageService = messageService;
         InitializeComponent();
         setupTheme();
      }

      private void setupTheme()
      {
         this.MaximizeBox = false;

         materialSkinManager = MaterialSkinManager.Instance;
         materialSkinManager.AddFormToManage(this);
         if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
         }
         else if (Mock_UI.Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
         {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
         }
      }
   }
}
