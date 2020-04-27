import pandas as pd
import numpy as np

nfl_data = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/NFL Play by Play 2009-2017 (v4).csv")
sf_permits = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/Building_Permits.csv")
np.random.seed(0)
nfl_data.sample(5)
missing_values_count = nfl_data.isnull().sum()
missing_values_count[0:10]
total_cells = np.product(nfl_data.shape)
total_missing = missing_values_count.sum()
print((total_missing/total_cells) * 100)

# My Turn --------------------------------------------------------------------------------
"""
Yes
"""
#------------------------------------------------------------------------------------------

#My Turn ---------------------------------------------------------------------------------
missing_values_count = sf_permits.isnull().sum()
missing_values_count[0:10]
total_cells = np.product(sf_permits.shape)
total_missing = missing_values_count.sum()
print((total_missing/total_cells) * 100)
#------------------------------------------------------------------------------------------

#My Turn ---------------------------------------------------------------------------------
missing_values_count[40] # Number missing Zipcode values in sf_permits
#------------------------------------------------------------------------------------------

nfl_data.dropna()
columns_with_na_dropped = nfl_data.dropna(axis=1)
columns_with_na_dropped.head()
print("Columns in original dataset: %d \n" % nfl_data.shape[1])
print("Columns with na dropped: %d" % columns_with_na_dropped.shape[1])

#My Turn ---------------------------------------------------------------------------------
sf_permits.dropna()
columns_with_na_dropped = sf_permits.dropna(axis=1)
columns_with_na_dropped.head()
print("Columns in original dataset: %d \n" % sf_permits.shape[1]) # 43
print("Columns with na dropped: %d" % columns_with_na_dropped.shape[1]) # 12
#------------------------------------------------------------------------------------------

subset_nfl_data = nfl_data.loc[:, 'EPA':'Season'].head()
subset_nfl_data
subset_nfl_data.fillna(0)
subset_nfl_data.fillna(method = 'bfill', axis=0).fillna(0)

#My Turn ---------------------------------------------------------------------------------
subset_sf_permits = sf_permits.loc[:, 'Plansets':'Record ID'].head()
subset_sf_permits
subset_sf_permits.fillna(0)
subset_sf_permits.fillna(method = 'bfill', axis=0).fillna(0)
#------------------------------------------------------------------------------------------

"""------------------------Task1 end------------------------"""

"""------------------------Task2----------------------------"""
import pandas as pd
import numpy as np
from scipy import stats
from mlxtend.preprocessing import minmax_scaling
import seaborn as sns
import matplotlib.pyplot as plt

kickstarters_2017 = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201801.csv")
np.random.seed(0)
original_data = np.random.exponential(size = 1000)
scaled_data = minmax_scaling(original_data, columns = [0])
fig, ax = plt.subplots(1, 2)
sns.distplot(original_data, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(scaled_data, ax=ax[1])
ax[1].set_title("Scaled Data")
normalized_data = stats.boxcox(original_data)
fig, ax = plt.subplots(1, 2)
sns.distplot(original_data, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(scaled_data, ax=ax[1])
ax[1].set_title("Scaled Data")

#My Turn ---------------------------------------------------------------------------------
"""
A part)
Normalizing the variable will make more sense.
Since number of students that study 0 hours is persumably equal to students that study
4 hours. An average student will study 2 hours (mean). Students are distributed normally
across either side of Students that study 2 hours.

B Part)
Since pushups and jumpings are measured on different scales, so scaling the
data on an optimal scale (0 to 1) will make more sense.
"""
#------------------------------------------------------------------------------------------

usd_goal = kickstarters_2017.usd_goal_real
scaled_data = minmax_scaling(usd_goal, columns = [0])
fig, ax=plt.subplots(1,2)
sns.distplot(kickstarters_2017.usd_goal_real, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(scaled_data, ax=ax[1])
ax[1].set_title("Scaled data")

#My Turn ---------------------------------------------------------------------------------
usd_goal = kickstarters_2017.goal
scaled_data = minmax_scaling(usd_goal, columns = [0])
fig, ax=plt.subplots(1,2)
sns.distplot(kickstarters_2017.goal, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(scaled_data, ax=ax[1])
ax[1].set_title("Scaled data")
#------------------------------------------------------------------------------------------

index_of_positive_pledges = kickstarters_2017.usd_pledged_real > 0
positive_pledges = kickstarters_2017.usd_pledged_real.loc[index_of_positive_pledges]
normalized_pledges = stats.boxcox(positive_pledges)[0]
fig, ax=plt.subplots(1,2)
sns.distplot(positive_pledges, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(normalized_pledges, ax=ax[1])
ax[1].set_title("Normalized data")

#My Turn ---------------------------------------------------------------------------------
index_of_positive_pledges = kickstarters_2017.pledged > 0
positive_pledges = kickstarters_2017.pledged.loc[index_of_positive_pledges]
normalized_pledges = stats.boxcox(positive_pledges)[0]
fig, ax=plt.subplots(1,2)
sns.distplot(positive_pledges, ax=ax[0])
ax[0].set_title("Original Data")
sns.distplot(normalized_pledges, ax=ax[1])
ax[1].set_title("Normalized data")
#------------------------------------------------------------------------------------------

"""------------------------Task2 end------------------------"""

"""------------------------Task3----------------------------"""
import pandas as pd
import numpy as np
import seaborn as sns
import datetime

earthquakes = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/earthquake-database.csv")
landslides = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/catalog.csv")
volcanos = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/volcanic-eruption.csv")

np.random.seed(0)
print(landslides['date'].head())
landslides['date'].dtype

#My Turn ---------------------------------------------------------------------------------
earthquakes['Date'].dtype
#------------------------------------------------------------------------------------------

landslides['date_parsed'] = pd.to_datetime(landslides['date'], format = "%m/%d/%y") # Error
landslides['date_parsed'].head()

#My Turn ---------------------------------------------------------------------------------
#------------------------------------------------------------------------------------------

day_of_month_landslides = landslides['date'].dt.day
day_of_month_landslides = landslides['date_parsed'].dt.day

#My Turn ---------------------------------------------------------------------------------
#------------------------------------------------------------------------------------------

day_of_month_landslides = day_of_month_landslides.dropna()
sns.distplot(day_of_month_landslides, kde=False, bins=31)

#My Turn ---------------------------------------------------------------------------------
#------------------------------------------------------------------------------------------

volcanos['Last Known Eruption'].sample(5)

"""------------------------Task3 end------------------------"""

"""------------------------Task4----------------------------"""
import pandas as pd
import numpy as np
import chardet  # Install Chardet

np.random.seed(0)

before = "This is the euro symbol: €"
after = before.encode("utf-8", errors = "replace")
type(after)
after
print(after.decode("utf-8"))
print(after.decode("ascii"))

before = "This is the euro symbol: €"
after = before.encode("ascii", errors = "replace")
print(after.decode("ascii"))

#My Turn ---------------------------------------------------------------------------------
before = "This is the dollar symbol: $"
after = before.encode("ascii", errors = "replace")
print(after.decode("ascii"))

before = "This is the hash symbol: #"
after = before.encode("ascii", errors = "replace")
print(after.decode("ascii"))

before = "This is the chinese symbol: 你好"
after = before.encode("ascii", errors = "replace")
print(after.decode("ascii"))

before = "This is the hindi symbol: नमस्ते"
after = before.encode("ascii", errors = "replace")
print(after.decode("ascii"))

#------------------------------------------------------------------------------------------

kickstarter_2016 = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201612.csv")
with open("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201612.csv", 'rb') as rawdata:
    result = chardet.detect(rawdata.read(10000))
print(result)

kickstarter_2016 = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201612.csv", encoding = 'Windows-1252')
kickstarter_2016.head()

kickstarter_2016 = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201612.csv", encoding = 'utf-8')
kickstarter_2016.head()

#My Turn ---------------------------------------------------------------------------------
kickstarter_2016 = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/ks-projects-201612.csv", encoding = 'Windows-1252')
kickstarter_2016.head()

with open("C:/Users/Hamza Ch/Desktop/lab 09/PoliceKillingsUS.csv", 'rb') as rawdata:
    result = chardet.detect(rawdata.read(10000))
print(result)

police_killings = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/PoliceKillingsUS.csv", encoding = 'Windows-1252')
#------------------------------------------------------------------------------------------

kickstarter_2016.to_csv("ks-projects-201801-utf8.csv")

#My Turn ---------------------------------------------------------------------------------
police_killings.to_csv("PoliceKillingsUS-utf8.csv")
#------------------------------------------------------------------------------------------

with open("C:/Users/Hamza Ch/Desktop/lab 09/PakistanSuicideAttacks Ver 11 (30-November-2017).csv", 'rb') as rawdata:
    result = chardet.detect(rawdata.read(10000))
print(result)

suicide_attacks = pd.read_csv("C:/Users/Hamza Ch/Desktop/lab 09/PakistanSuicideAttacks Ver 11 (30-November-2017).csv", encoding = 'Windows-1252')

cities = suicide_attacks['City'].unique()
cities.sort()
print(cities)

suicide_attacks['City'] = suicide_attacks['City'].str.lower()
suicide_attacks['City'] = suicide_attacks['City'].str.strip()

#My Turn ---------------------------------------------------------------------------------
province = suicide_attacks['Province'].unique()
print(province)
suicide_attacks['Province'] = suicide_attacks['Province'].str.lower()
suicide_attacks['Province'] = suicide_attacks['Province'].str.strip()

#------------------------------------------------------------------------------------------

"""------------------------Task4 end------------------------"""

"""------------------------Task5----------------------------"""
import pandas as pd
import numpy as np
import fuzzywuzzy # Install fuzzywuzzy
from fuzzywuzzy import process
import chardet
np.random.seed(0)

matches = fuzzywuzzy.process.extract("d.i khan", cities, limit=10, scorer=fuzzywuzzy.fuzz.token_sort_ratio)
print(matches)

def replace_matches_in_column(df, column, string_to_match, min_ratio = 90):
    strings = df[column].unique()
    matches = fuzzywuzzy.process.extract(string_to_match, strings, limit=10, scorer=fuzzywuzzy.fuzz.token_sort_ratio)
    close_matches = [matches[0] for matches in matches if matches[1] >= min_ratio]
    rows_with_matches = df[column].isin(close_matches)
    df.loc[rows_with_matches, column] = string_to_match
    print("All done!")

replace_matches_in_column(df=suicide_attacks, column='City', string_to_match="d.i khan")

cities = suicide_attacks['City'].unique()
cities.sort()
print(cities)

#My Turn ---------------------------------------------------------------------------------
matches = fuzzywuzzy.process.extract("kuram agency", cities, limit=10, scorer=fuzzywuzzy.fuzz.token_sort_ratio)
replace_matches_in_column(df=suicide_attacks, column='City', string_to_match="kuram agency")
#------------------------------------------------------------------------------------------
"""------------------------Task5 end----------------------------"""
