using UnityEngine;
using System.Collections;

namespace KLib {
	/// <summary>
	/// This class deals with the replay data
	/// Notice: instead of recording what each frame the player did, it deals with what has CHANGED for a certain frame
	/// </summary>
	public class KRepData {
		public KRepData(KFrameData[] frame_data, int[] _seeds) {
			frameData = frame_data;
			seeds = _seeds;
		}

		//The idea is to record KFrameData even if there is no action
		//Just declare KFrameData as null
		//This causes larger data usage, but it is faster. Much better than dictionary search performance
		public KFrameData[] frameData;
		public int[] seeds;
	}

	public class KFrameData {
		public KFrameData(int frame_num, KKeyAction _data) {
			frameNum = frame_num;
			data = _data;
		}

		public int frameNum;
		public KKeyAction data;
	}
}
