using System.Threading.Tasks;
using Discord;
using Discord.Commands;

public class AudioModule : ModuleBase<ICommandContext>
{
    public static bool discordbot = false;
    public static AudioService service1;
    public static IGuild contextguild;
    public static IMessageChannel contextchannel;
    private readonly AudioService _service;
    public AudioModule(AudioService service)
    {
        _service = service;
        service1 = service;
    }
    [Command("join", RunMode = RunMode.Async)]
    public async Task JoinCmd()
    {
        await _service.JoinAudio(Context.Guild, (Context.User as IVoiceState).VoiceChannel);
        contextguild = Context.Guild;
        contextchannel = Context.Channel;
        discordbot = true;
        await ReplyAsync("Joined channel");
        await _service.SendAudioAsync(Context.Guild, Context.Channel, "voice lines/sv bicas.wav");
    }
    [Command("leave", RunMode = RunMode.Async)]
    public async Task LeaveCmd()
    {
        await _service.LeaveAudio(Context.Guild);
        await ReplyAsync("bbx vaikai varau vogti");
    }

    [Command("play", RunMode = RunMode.Async)]
    public async Task PlayCmd([Remainder] string song)
    {
        await _service.SendAudioAsync(Context.Guild, Context.Channel, "voice lines/"+song+".wav");
    }
}