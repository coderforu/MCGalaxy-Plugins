using System;
using MCGalaxy;
using MCGalaxy.Events;
using MCGalaxy.Events.PlayerEvents;

namespace PluginTeamChat
{
	public class TeamChat : Plugin 
	{
		public override string creator { get { return "HeyItsJackson"; } }
		public override string MCGalaxy_Version { get { return "1.9.1.4"; } }
		public override string name { get { return "GangChatPlugin"; } }
		
		public override void Load(bool startup) {
			OnPlayerChatEvent.Register(DoTeamChat, Priority.Low);
		}
		
		public override void Unload(bool shutdown) {
			OnPlayerChatEvent.Unregister(DoTeamChat);
		}
		
		void DoTeamChat(Player p, string message) {
			if (p.cancelchat || message.Length <= 1 || message[0] != '=') return;
			
			if (p.Game.Team == null) {
				p.Message("You are not on a team, so cannot send a team message.");
			} else {
				p.Game.Team.Message(p, message.Substring(1));
			}
			p.cancelchat = true;
		}
	}
}
