﻿using System;
using System.Collections.Generic;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;

namespace TextToSpeech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintAllVoices();

            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();
            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Female);

            // We can't reference .NET Core from Framework.
            // Class1.GenerateString();
            synth.Speak($"Hello. My name is {synth.Voice.Name}. Type something and press enter, and I will say it. Type QUIT to quit.");

            Console.WriteLine("What should I say? Type QUIT to quit.");
            Console.Write("> ");
            var input = Console.ReadLine();
     
            while (input.Trim().ToUpper() != "QUIT")
            {
                synth.Speak(input);
                Console.WriteLine("Now? (QUIT to quit.)");
                Console.Write("> ");
                input = Console.ReadLine();
            }

            synth.Speak("BYE!");
        }
        

        static void PrintAllVoices()
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Output information about all of the installed voices.   
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    string AudioFormats = "";
                    foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                    {
                        AudioFormats += String.Format("{0}\n",
                            fmt.EncodingFormat.ToString());
                    }

                    Console.WriteLine(" Name:          " + info.Name);
                    Console.WriteLine(" Culture:       " + info.Culture);
                    Console.WriteLine(" Age:           " + info.Age);
                    Console.WriteLine(" Gender:        " + info.Gender);
                    Console.WriteLine(" Description:   " + info.Description);
                    Console.WriteLine(" ID:            " + info.Id);
                    Console.WriteLine(" Enabled:       " + voice.Enabled);
                    if (info.SupportedAudioFormats.Count != 0)
                    {
                        Console.WriteLine(" Audio formats: " + AudioFormats);
                    }
                    else
                    {
                        Console.WriteLine(" No supported audio formats found");
                    }

                    string AdditionalInfo = "";
                    foreach (string key in info.AdditionalInfo.Keys)
                    {
                        AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
                    }

                    Console.WriteLine(" Additional Info - " + AdditionalInfo);
                    Console.WriteLine();
                }
            }
        }
    }
}
