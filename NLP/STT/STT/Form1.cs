using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpeechLib;

namespace STT
{
    public partial class Form1 : Form
    {
        SpSharedRecoContext recoContext;
        ISpeechRecoGrammar myGramer;

        public Form1()
        {
            InitializeComponent();
            recoContext = new SpSharedRecoContext();

            myGramer = recoContext.CreateGrammar(0);
            myGramer.CmdLoadFromFile("Mouse.XML", SpeechLoadOption.SLODynamic);
            myGramer.CmdSetRuleIdState(0, SpeechRuleState.SGDSActive);

            recoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(recoContext_Recognition);
            recoContext.StartStream += new _ISpeechRecoContextEvents_StartStreamEventHandler(recoContext_StartStream);

        }

        void recoContext_StartStream(int StreamNumber, object StreamPosition)
        {
            throw new NotImplementedException();
        }

        void recoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            textBox1.Text += Result.PhraseInfo.GetText(0, -1, true);
            label1.Text = Result.PhraseInfo.Rule.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechLib.SpVoice voice = new SpeechLib.SpVoice();
            voice.Speak("This is a test", SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync);
            voice.WaitUntilDone(500);
        }
    }
}
