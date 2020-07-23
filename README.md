# Text Analysis API

*This project forms part of our developer interview process.*
*Unfortunately, we can only provide high level feedback for any submissions we receive.*

## Background

The text analysis API provides a single endpoint that accepts text from clients. The API analyses provided text to identify any words which contain `A` or `E` as their second letter. Results from the API are broken down by line number and letter. 

The API specification contains the following information:
- The line numbers of results should start at 0.
- The case of letters is not important.
- A word is defined as any continuous group of non-whitespace characters. Clients must remove punctuation before sending text to the API.
- The input text size should not exceed 1000 characters.
- Lines in the text which contain no matching words shouldn't appear in the output `lineResults`.

The API specification also contains and example request:
``` json
{
    "text": "Bee TREE   CAT ant     eel elk\r\nGreen Red Blue Yellow"
}
```

... which should produce the following response:
``` json
{
    "lineResults": [
        {
            "lineNumber": 0,
            "letterOccurrences": [
                {
                    "letter": "A",
                    "words": [
                        "CAT"
                    ]
                },
                {
                    "letter": "E",
                    "words": [
                        "Bee",
                        "eel"
                    ]
                }
            ]
        },
        {
            "lineNumber": 1,
            "letterOccurrences": [
                {
                    "letter": "A",
                    "words": []
                },
                {
                    "letter": "E",
                    "words": [
                        "Red",
                        "Yellow"
                    ]
                }
            ]
        }
    ]
}
```

## Part 1 · Review · ~1.5 hrs

The version of the API in this repository has been developed by a junior member of the team. You have been asked to perform a thorough review of the current codebase. Comment on the good and bad aspects of the code. For any issues you find, make a note of the steps you would take to fix the problem. It is **NOT** necessary to actually implement any fixes you suggest. You can provide your review as a text or markdown file. We are more concerned with the content and structure of your review than its appearance.

*Note: The API does not authenticate its clients. This is to keep the amount of code we are asking you to review to a minimum. You can assume that this is not a public API and that the API perfectly authenticates its clients.*

### Tips

- Document your notes in a structured way.
- Where you a referencing a specific line of code, be sure to include both the line number and file name.
- If you find yourself running out of time to complete the review, submit some high level notes for items you don't have time expand on . You may then be asked to expand on these notes if you are invited to the interview stage.

## Part 2 · Design · ~30 mins

There are ambitious plans to expand the API in the future. We're considering adding support for analysing the positions of `I`, `O` and `U`. One of the clients of the API may also need to start looking for words which have `A` and `E` as their third letter.

Write a short (1 or 2 paragraphs) plan describing what can be done now to make these potential changes easier to implement in the future. You may include this at the end of your review or as a separate text/markdown file. Your plan should **NOT** describe how to make these changes, only how refactor the API's existing functionality such that these changes could be made more easily in the future.
