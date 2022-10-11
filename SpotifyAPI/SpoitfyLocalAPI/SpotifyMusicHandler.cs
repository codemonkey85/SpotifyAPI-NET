﻿using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SpotifyAPI.SpotifyLocalAPI
{
    public class SpotifyMusicHandler
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("nircmd.dll")]
        private static extern bool DoNirCmd(String NirCmdStr);

        private RemoteHandler rh;
        private StatusResponse sr;

        //Constants for the Keyboard Event (NextTrack + PreviousTrack)
        private const byte VK_MEDIA_NEXT_TRACK = 0xb0;

        private const byte VK_MEDIA_PREV_TRACK = 0xb1;
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;

        public SpotifyMusicHandler()
        {
            rh = RemoteHandler.GetInstance();
        }

        /// <summary>
        /// Simulates a KeyPress
        /// </summary>
        /// <param name="keyCode">The keycode for the represented Key</param>
        private void PressKey(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        /// <summary>
        /// Checks if a song is playing
        /// </summary>
        /// <returns>True if a song is playing, false if not</returns>
        public Boolean IsPlaying()
        {
            return sr.playing;
        }

        /// <summary>
        /// Returns the current Volume
        /// </summary>
        /// <returns>A value between 0 and 1</returns>
        public double GetVolume()
        {
            return sr.volume;
        }

        /// <summary>
        /// Plays a Spotify URI within an optional context.
        /// </summary>
        /// <param name="uri">The Spotify URI. Can be checked with <seealso cref="SpotifyLocalAPIClass.IsValidSpotifyURI"/></param>
        /// <param name="context">The context in which to play the specified <paramref name="uri"/>. </param>
        /// <remarks>
        /// Contexts are basically a queue in spotify. a song can be played within a context, meaning that hitting next / previous would lead to another song. Contexts are leveraged by widgets as described in the "Multiple tracks player" section of the following documentation page: https://developer.spotify.com/technologies/widgets/spotify-play-button/
        /// </remarks>
        public void PlayURL(String uri, String context = "")
        {
            rh.SendPlayRequest(uri, context);
        }

        /// <summary>
        /// Adds a Spotify URI to the Queue
        /// </summary>
        /// <param name="uri">The Spotify URI. Can be checked with <seealso cref="SpotifyLocalAPIClass.IsValidSpotifyURI"/></param>
        public void AddToQueue(String uri)
        {
            rh.SendQueueRequest(uri);
        }

        /// <summary>
        /// Checks if the current "Track" is an Advert
        /// </summary>
        /// <returns>True if it's an Advert, false if not</returns>
        public Boolean IsAdRunning()
        {
            return !sr.next_enabled && !sr.prev_enabled;
        }

        /// <summary>
        /// Returns the current Track object
        /// </summary>
        /// <returns>Returns the current track object</returns>
        public Track GetCurrentTrack()
        {
            return sr.track;
        }

        /// <summary>
        /// Skips the current song (Using keypress simulation)
        /// </summary>
        public void Skip()
        {
            PressKey(VK_MEDIA_NEXT_TRACK);
            //rh.SendSkipRequest();
        }

        /// <summary>
        /// Emulates the "Previous" Key (Using keypress simulation)
        /// </summary>
        public void Previous()
        {
            PressKey(VK_MEDIA_PREV_TRACK);
            //rh.SendPreviousRequest();
        }

        /// <summary>
        /// Returns the current track postion
        /// </summary>
        /// <returns>A double between 0 and ∞</returns>
        public double GetTrackPosition()
        {
            return sr.playing_position;
        }

        /// <summary>
        /// Mutes Spotify (Requires nircmd.dll)
        /// </summary>
        public void Mute()
        {
            if (File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 1");
        }

        /// <summary>
        /// Unmutes Spotify (Requires nircmd.dll)
        /// </summary>
        public void UnMute()
        {
            if (File.Exists("nircmd.dll"))
                DoNirCmd("muteappvolume spotify.exe 0");
        }

        /// <summary>
        /// Pause function
        /// </summary>
        public void Pause()
        {
            rh.SendPauseRequest();
        }

        /// <summary>
        /// Play function
        /// </summary>
        public void Play()
        {
            rh.SendPlayRequest();
        }

        /// <summary>
        /// Returns all Informations gathered by the JSON Request
        /// </summary>
        /// <returns>A StatusResponse object</returns>
        public StatusResponse GetStatusResponse()
        {
            return sr;
        }

        //Used internaly
        internal void Update(StatusResponse sr)
        {
            this.sr = sr;
        }
    }
}