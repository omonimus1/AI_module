"""Description
Using the provided dataset, develop a sentiment classification model for the given dataset. Your
proposed model must be a decision tree with an appropriate text representation method
proposed by you. Specifically, you will need to:
Initially explore the dataset and create two functions that return the unigrams and bigrams of
the input data and show the 20 most used unigrams and bigrams.
Choose and implement a text representation techniques (such as bag of words). Justify your
choice.
Develop a decision tree, which uses as input the text representations from the previous step.
Evaluate your decision tree by using appropriate metrics. Explain why you chose the selected
metrics. """

# import IMBD dataset from keras
from keras.datasets import imdb
(training_data, training_targets), (testing_data, testing_targets) = imdb.load_data()

print(training_data, training_targets, testing_data, testing_targets)
