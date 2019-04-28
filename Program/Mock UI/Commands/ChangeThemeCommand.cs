using ChatApp;
using Mock_UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mock_UI.Commands
{
   /// <summary>
   /// Concrete implementation of UndoCommand for changing the theme.
   /// </summary>
   class ChangeThemeCommand : UndoCommand
   {
      private MainForm mainForm;
      private EnumTheming previousThemeEnum;
      private EnumTheming themeEnum;

      /// <summary>
      /// Stores the previously selected theme (one stored in settings), the new theme, and the parent form
      /// </summary>
      /// <param name="themeEnum">Theme to be changed to</param>
      /// <param name="mainForm">The parent form</param>
      public ChangeThemeCommand(EnumTheming themeEnum, MainForm mainForm)
      {
         if(Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.light))
            previousThemeEnum = EnumTheming.light;
         else if (Properties.Settings.Default.Theme == EnumExtensions.GetEnumDescription(EnumTheming.dark))
            previousThemeEnum = EnumTheming.dark;

         this.themeEnum = themeEnum;
         this.mainForm = mainForm;
      }

      /// <summary>
      /// Change the theme to the new one selected.
      /// </summary>
      public override void Execute()
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(themeEnum);
         Mock_UI.Properties.Settings.Default.Save();

         if (themeEnum == EnumTheming.dark)
            mainForm.setDarkTheme();
         else if (themeEnum == EnumTheming.light)
            mainForm.setLightTheme();
      }

      /// <summary>
      /// Change the theme back to the previously selected theme.
      /// </summary>
      public override void Undo()
      {
         Mock_UI.Properties.Settings.Default.Theme = EnumExtensions.GetEnumDescription(previousThemeEnum);
         Mock_UI.Properties.Settings.Default.Save();

         if (previousThemeEnum == EnumTheming.dark)
            mainForm.setDarkTheme();
         else if (previousThemeEnum == EnumTheming.light)
            mainForm.setLightTheme();
      }
   }
}
