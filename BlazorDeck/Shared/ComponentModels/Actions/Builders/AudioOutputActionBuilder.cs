using System.ComponentModel.DataAnnotations;

namespace BlazorDeck.Shared.ComponentModels.Actions.Builders
{
    public class AudioOutputActionBuilder : ITileActionBuilder, IBuilderFor<AudioOutputAction>
    {
        [Required]
        [Display(Name = "Audio device name")]
        public string Name { get; set; }
        public AudioOutputActionBuilder()
        {

        }

        public AudioOutputActionBuilder(AudioOutputAction audioOutputAction)
        {
            Name = audioOutputAction.Content as string;
        }
        public ITileAction BuildTileAction()
        {
            return new AudioOutputAction(Name);
        }
    }
}
