import numpy as np
import pandas as pd
from pandas import Series, DataFrame
import matplotlib as mpl
import matplotlib.pyplot as plt
import seaborn as sns
%matplotlib inline
titanic_df = pd.read_csv('C:/Users/Hamza Ch/Desktop/lab 10/train.csv')
titanic_df.head()
titanic_df.columns
titanic_df.info()
titanic_df.groupby('Pclass')['Pclass'].count()
fg = sns.factorplot('Pclass', data=titanic_df, kind='count', aspect=1.5)
fg.set_xlabels('Class')
titanic_df.groupby('Sex')['Sex'].count()
sns.factorplot('Sex', data=titanic_df, kind='count', aspect=1.5)
titanic_df.groupby(['Sex', 'Pclass'])['Sex'].count()
g = sns.factorplot('Pclass', data=titanic_df, hue='Sex', kind='count', aspect=1.75)
g.set_xlabels('Class')
titanic_df.pivot_table('Survived', 'Sex', 'Pclass', aggfunc=np.sum, margins=True)
not_survived = titanic_df[titanic_df['Survived']==0]
len(not_survived)
sns.factorplot('Survived', data=titanic_df, kind='count')
not_survived.pivot_table('Survived', 'Sex', 'Pclass', aggfunc=len, margins=True)
table = pd.crosstab(index=[titanic_df.Survived,titanic_df.Pclass],columns=[titanic_df.Sex,titanic_df.Embarked])
table.unstack()
table.columns, table.index
table.columns.set_levels(['Female', 'Male'], level=0, inplace=True)
table.columns.set_levels(['Cherbourg','Queenstown','Southampton'], level=1, inplace=True)
print('Average and median age of passengers are %0.f and %0.f years old respectively'%(titanic_df.Age.mean(),titanic_df.Age.median()))
titanic_df.Age.describe()
age = titanic_df['Age'].dropna()
age_dist = sns.distplot(age)
age_dist.set_title("Distribution of Passengers' Ages")
titanic_df['Age'].hist(bins=50)
titanic_df['Parch'].dtype, titanic_df['SibSp'].dtype, len(titanic_df.Cabin.dropna())
def male_female_child(passenger):
    age, sex = passenger
    if age < 16:
        return 'child'
    else:
        return sex
titanic_df['person'] = titanic_df[['Age', 'Sex']].apply(male_female_child, axis=1)
titanic_df[:10]
sns.factorplot('Pclass', data=titanic_df, kind='count', hue='person', order=[1,2,3],hue_order=['child','female','male'], aspect=2)
titanic_df['person'].value_counts()
sns.factorplot('Pclass', data=titanic_df, kind='count', hue='person', col='Survived', order=[1,2,3], hue_order=['child','female','male'], aspect=1.25, size=5)
fig = sns.FacetGrid(titanic_df, hue='Sex', aspect=4)
fig.map(sns.kdeplot, 'Age', shade=True)
oldest = titanic_df['Age'].max()
fig.set(xlim=(0,oldest))
fig.set(title='Distribution of Age Grouped by Gender')
fig.add_legend()
fig = sns.FacetGrid(titanic_df, hue='person', aspect=4)
fig.map(sns.kdeplot, 'Age', shade=True)
oldest = titanic_df['Age'].max()
fig.set(xlim=(0,oldest))
fig.add_legend()
fig = sns.FacetGrid(titanic_df, hue='Pclass', aspect=4)
fig.map(sns.kdeplot, 'Age', shade=True)
oldest = titanic_df['Age'].max()
fig.set(xlim=(0,oldest))
fig.set(title='Distribution of Age Grouped by Class')
fig.add_legend()
deck = titanic_df['Cabin'].dropna()
deck.head()
from collections import Counter
d=[]
for c in deck:
    d.append(c[0])
d[0:10]
cabin_df = DataFrame(d)
cabin_df.columns=['Cabin']
sns.factorplot('Cabin', data=cabin_df, kind='count', order=['A','B','C','D','E','F','G','T'], aspect=2, palette='winter_d')
cabin_df = cabin_df[cabin_df['Cabin'] != 'T']
sns.factorplot('Cabin', data=cabin_df, kind='count', order=['A','B','C','D','E','F','G'], aspect=2, palette='Greens_d')
url = 'http://matplotlib.org/api/pyplot_summary.html?highlight=colormaps#matplotlib.pyplot.colormaps'
import webbrowser
webbrowser.open(url)
sns.factorplot('Embarked', data=titanic_df, kind='count', hue='Pclass', hue_order=range(1,4), aspect=2,order = ['C','Q','S'])
titanic_df.Embarked.value_counts()
port = pd.crosstab(index=[titanic_df.Pclass], columns=[titanic_df.Embarked])
port.columns = [['Cherbourg','Queenstown','Southampton']]
port.index
port.columns
port.index=[['First','Second','Third']]
port
titanic_df[['SibSp','Parch']].head()
alone_df = titanic_df[(titanic_df['SibSp'] == 0) & (titanic_df['Parch']==0)]
not_alone_df = titanic_df[(titanic_df['SibSp'] != 0) | (titanic_df['Parch']!=0)]
not_alone_df['Alone'] = 'With family'
comb = [alone_df, not_alone_df]
titanic_df = pd.concat(comb).sort_index()
[len(alone_df), len(not_alone_df)]
alone_df.head()
not_alone_df.head()
titanic_df.head()
fg=sns.factorplot('Alone', data=titanic_df, kind='count', hue='Pclass', col='person', hue_order=range(1,4),palette='Blues')
fg.set_xlabels('Status')
titanic_df['Survivor'] = titanic_df.Survived.map({0:'no', 1:'yes'})
sns.factorplot('Pclass','Survived', hue='person', data=titanic_df, order=range(1,4), hue_order = ['child','female','male'])
sns.factorplot('Survivor', data=titanic_df, hue='Pclass', kind='count', palette='Pastel2', hue_order=range(1,4), col='person')
sns.lmplot('Age', 'Survived', data=titanic_df)
sns.lmplot('Age', 'Survived', data=titanic_df, hue='Sex')
sns.lmplot('Age', 'Survived', hue='Pclass', data=titanic_df, palette='winter', hue_order=range(1,4))
generations = [10,20,40,60,80]
sns.lmplot('Age','Survived',hue='Pclass',data=titanic_df,x_bins=generations, hue_order=[1,2,3])
titanic_df.columns
titanic_DF = titanic_df.dropna(subset=['Cabin'])
d[0:10]
len(titanic_DF), len(d)

titanic_DF = titanic_DF[titanic_DF.Deck != 'T'] # Error

titanic_DF.head()

sns.factorplot('Deck', 'Survived', data=titanic_DF, order=['A','B','C','D','E','F','G']) # Error

sns.factorplot('Alone', 'Survived', data=titanic_df, palette='winter')
sns.factorplot('Alone', 'Survived', data=titanic_df, palette='winter', hue='person', hue_order=['child', 'female', 'male'])
sns.factorplot('Alone', 'Survived', data=titanic_df, palette='summer', hue='person', hue_order=['child', 'female', 'male'], col='Pclass', col_order=[1,2,3])
