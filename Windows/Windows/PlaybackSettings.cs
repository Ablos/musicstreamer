using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
	public static class PlaybackSettings
	{
		public enum RepeatState { NONE, REPEAT_ALL, REPEAT_ONE };

		public static bool shuffle = false;
		public static RepeatState repeatState = RepeatState.NONE;
		public static bool isPaused = true;
		public static float volume = 100f;

		public static bool edittingTime = false;
		public static bool timeSelected = false;

		public static bool edittingVolume = false;
		public static bool volumeSelected = false;
	}
}
