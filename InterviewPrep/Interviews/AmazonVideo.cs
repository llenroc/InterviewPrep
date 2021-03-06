﻿using System.Collections.Generic;

namespace InterviewPrep.Interviews
{
    /*
        You are working on developing a movie with Amazon Video and want to devise an application to easily 
        break up individual shots in a video into scenes. There is already an algorithm that breaks the video 
        up into shots (short sequences from a particular camera angle) and lables them.

        Write a function which will partition a sequence of labels into minimal subsequences so that no labels 
        appear in more than one subsequence. The output should be the length of each subsequence.

        Input:
        The input to the function/method consists of an argument - inputList, a list of characters representing 
        the sequence of shots.

        Output:
        Return a list of integers representing the length of each scene, in the order in which it appears in the 
        given sequence of shots.

        Example:

        Input:
        inputList = [a,b,a,b,c,b,a,c,a,d,e,f,e,g,d,e,h,i,j,h,k,l,i,j]
        // 'a','b','a','b','c','b','a','c','a','d','e','f','e','g','d','e','h','i','j','h','k','l','i','j'


        Output:
        [9, 7, 8]
    
        Explanation:
        The correct partitioning is:
        a,b,a,b,c,b,a,c,a,/d,e,f,e,g,d,e,/h,i,j,h,k,l,i,j
    
        To ensure that no label appears in more than one subsequence, subsequencea are as small as possible, 
        and subsequences partition the sequence. The length of these subsequences are 9, 7 and 8.

        Solution:
        Merge Intervals. For each letter, use an array or hash table to store the first index and last index 
        (this will act as the start and end point for each interval). Then combine overlapping intervals at 
        the end. The length of each interval (end index - start index + 1) will be part of the output.
    */
    class AmazonVideo
    {
        class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }
        }


        public List<int> LengthEachScene(char[] arr)
        {
            List<int> result = new List<int>();

            List<Interval> list = new List<Interval>();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    list[dict[arr[i]]].End = i;
                }
                else
                {
                    dict.Add(arr[i], index);
                    list.Add(new Interval() { Start = i });
                    index++;
                }
            }

            Interval previous = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                Interval current = list[i];

                if (previous.End < current.Start)
                {
                    result.Add(previous.End - previous.Start + 1);
                    previous.Start = current.Start;
                    previous.End = current.End;
                }
                else
                {
                    if (previous.End > current.End)
                    {
                        continue;
                    }
                    else
                    {
                        previous.End = current.End;
                    }
                }
            }

            result.Add(previous.End - previous.Start + 1);

            return result;
        }
    }
}
