# from  google.colab import drive
import pandas as pd
from sklearn.tree import DecisionTreeClassifier 
# drive.mount('/content/gdrive')

# set local path where notebooks and data folders are located
path = ""
data_path = path + "zoo.data"
print(data_path)

#Import the dataset (dropped the first column with the animal names)
dataset = pd.read_csv(data_path, header=None, usecols=[*range(1, 18)])

#Split the data into a training and a testing set
train_features = dataset.iloc[:80,:-1]
test_features = dataset.iloc[80:,:-1]
train_labels = dataset.iloc[:80,-1]
test_labels = dataset.iloc[80:,-1]

tree = DecisionTreeClassifier(criterion = 'entropy').fit(train_features,train_labels)

#The accuracy is then calculated through the score function offered by sklearn
print("The prediction accuracy is: ",tree.score(test_features,test_labels)*100,"%")

#If you need to use the trained classifier in an actual application, you can use the function "predict"
#to get the prediction on the test set as follows
prediction = tree.predict(test_features)