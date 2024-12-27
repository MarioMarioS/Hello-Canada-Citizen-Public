/*
DEMO ONLY
NOT FULL CODE BASE
THIS IS TO AVOID PIRACY AS THIS IS A COMMERCIAL APP.
*/

    public void PopulateNewQuestion()
    {
        playerSubmittedAnswer = "x";
        CheckIfPracticeTestFinished();
        //Get random number, list used to avoid duplicate rolls
        if (rndNumsToRoll.Count() > 2)
        {
            do
            {
                rnd = Random.Range(0, activeQuestionBank_Eng.Count());
            }
            while (!rndNumsToRoll.Contains(rnd));
        }
        else
        {
            RndNumsToRollReset();
            progressSliderQuestionsAnswered = 0f;
            ProgressSliderUpdate();
            rnd = Random.Range(0, activeQuestionBank_Eng.Count());
        }
        rndNumsToRoll.Remove(rnd);

        WriteGameBoard();

        //Set Gameboard to default status
        correctWrongGameObject.SetActive(false);
        nextQuestionGameObject.SetActive(false);
        abcdQuestionLayout.SetActive(true);
        answerOnlyTextGameObject.SetActive(true);
        LightDarkModeToggle();
        AnswerButtonsIsinteractable(true);

        CheckMcOrAnswerOnlyGameMode();
    }

    //Reset list of random numbers to draw from, avoid duplicate questions.
    void RndNumsToRollReset()
    {
        rndNumsToRoll.Clear();
        rndNumsToRoll = Enumerable.Range(0, activeQuestionBank_Eng.Count()).ToList();
    }

    void CheckMcOrAnswerOnlyGameMode()
    {
        //Multiple Choice GameMode Selected
        if (mcOrAnswerOnlySlider.value == 1 || practiceTestSelected == true)
        {
            abcdQuestionLayout.SetActive(true);
            answerOnlyTextGameObject.SetActive(false);
            Debug.Log("MC Game Mode");
        }
        // Only Answer Game Mode Selected
        else if (mcOrAnswerOnlySlider.value == 0 && practiceTestSelected == false)
        {
            Debug.Log("Practice Test Selected: " + practiceTestSelected);
            Debug.Log("Answer Only Game Mode");
            playerSubmittedAnswer = "x";
            CheckPlayerSubmittedAnswer();
            abcdQuestionLayout.SetActive(false);
            answerOnlyTextGameObject.SetActive(true);

            correctWrongGameObject.SetActive(false);
            nextQuestionGameObject.SetActive(true);
        }
    }
