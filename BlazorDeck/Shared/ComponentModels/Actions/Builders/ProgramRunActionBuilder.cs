using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class ProgramRunActionBuilder : ITileActionBuilder, IBuilderFor<ProgramRunAction>
    {
        [Required]
        [Display(Name = "Program path")]
        public string Path { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Program parameter(s)")]
        public string Param { get; set; }

        public ProgramRunActionBuilder()
        {

        }

        public ProgramRunActionBuilder(ProgramRunAction programRunAction)
        {
            Name = programRunAction.Content as string;
            Path = programRunAction.Path;
            Param = programRunAction.Param;
        }

        public ITileAction BuildTileAction()
        {
            return new ProgramRunAction(Name, Path, Param);
        }
    }
}
