# BetterBroadcast-qurre
Plugin for SCP:SL

Allows you to customize the broadcast.
- You can broadcast messages when a player enters the server, when the round starts and when the round ends. 
- You can also broadcast messages during a run, with an interval.

### Config Settings
Type | Config Value | Default Setting | Description
---- | ------------ | --------------- | ------------
Bool | bb_ply_join_msg_on | `true` | Enable Player Join Text
String | bb_ply_join_text | Welcome to my server %player%!| Broadcast message when player joined
Seconds | bb_ply_join_msg_dur | 10 | Duration of the message for the player
Bool | bb_start_round_msg_on | `true` | Enable Message After Round Started
String | bb_start_round_text | Good luck! | Broadcast message after round started
Seconds | bb_start_round_msg_dur | 10 | Duration of the message after round started
Bool | bb_end_round_msg_on | `true` | Enable Message After Round Ended
String | bb_end_round_text | Thank you for playing! | Broadcast message after round ended
Seconds | bb_end_round_msg_dur | 10 | Duration of the message after round ended
Bool | bb_round_msg_on | `true` | Enable messages during a round
String | bb_round_text | DISCORD: discord.gg/ | Broadcast message during round
Seconds | bb_round_dur | 10 | Duration of the message during round
Seconds | bb_round_msg_interval | 100 | The interval between broadcasts
Bool | bb_player_die_msg_on | `true` | Enable message when player die
String | bb_player_die_text | You were killed by player %killer% | Broadcast Message to Player
Seconds | bb_player_die_msg_dur | 4 | Duration of the message
