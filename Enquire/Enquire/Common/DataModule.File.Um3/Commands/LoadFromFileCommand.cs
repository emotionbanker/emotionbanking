using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Command;

namespace Compucare.Enquire.Common.DataModule.File.Um3.Commands
{
    public class LoadFromFileCommand : BaseCommand
    {
        private readonly String _filename;

        public LoadFromFileCommand(String filename)
        {
            Identifier = "Loading data from file...";
            _filename = filename;
        }

        public override void CustomProcess()
        {
            //TODO: load results

            //TODO: load um data

            //questions
            //users
            //combos
            //outputs
        }


        private void LoadDataIntoDatabase()
        {
            
        }
    }
}
