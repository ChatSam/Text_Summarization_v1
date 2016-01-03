﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSummarizerV1
{
    class SummarizerMain
    {
        static void Main(string[] args)
        {

            TextModel text = new TextModel();

            //get the document

            string path = "..\\..\\Resources\\Test\\inputNews.txt";

            //pass it to a string 
            string initialText = File.ReadAllText(path);

            //send it to preprocessing 
            Preprocessor preprocessor = new Preprocessor(initialText);

            text = preprocessor.RunPreprocessor();

            //send it to feature extraction
            FeatureExtractor featureExtractor = new FeatureExtractor(text);

            Dictionary<int,double> sentenceScores = featureExtractor.RunFeatureExtractor();

            //send it to sentence selection and assembly
            SentenceSelector sentenceSelector = new SentenceSelector(text);

            double thresholdValue = 5.0;

            List<int>rankedSentenceIds= sentenceSelector.RunSentenceSelector(sentenceScores, thresholdValue);

            //send to generate summary
            SummaryGenerator summaryGenerator = new SummaryGenerator(text);

            summaryGenerator.GenerateSummary(rankedSentenceIds);
            //evalute performance

            //save summary to doc

            //print summary 

        }
    }
}
