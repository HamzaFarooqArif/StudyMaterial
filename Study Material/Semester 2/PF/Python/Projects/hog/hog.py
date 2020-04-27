"""CS 61A Presents The Game of Hog."""

from dice import four_sided, six_sided, make_test_dice
from ucb import main, trace, log_current_line, interact

GOAL_SCORE = 100  # The goal of Hog is to score 100 points.


######################
# Phase 1: Simulator #
######################

def roll_dice(num_rolls, dice=six_sided):
    """Simulate rolling the DICE exactly NUM_ROLLS>0 times. Return the sum of
    the outcomes unless any of the outcomes is 1. In that case, return the
    number of 1's rolled.
    """
    # These assert statements ensure that num_rolls is a positive integer.
    assert type(num_rolls) == int, 'num_rolls must be an integer.'
    assert num_rolls > 0, 'Must roll at least once.'
    # BEGIN PROBLEM 1
    counter = 0
    dice_turn = 0
    pig_out_counter = 0
    total_score = 0
    while (counter < num_rolls):
        dice_turn = dice()
        if dice_turn == 1:
            pig_out_counter += 1
        else:
            total_score += dice_turn
        counter += 1
    if pig_out_counter > 0:
        return pig_out_counter
    else:
        return total_score + pig_out_counter
    # END PROBLEM 1


def free_bacon(opponent_score):
    """Return the points scored from rolling 0 dice (Free Bacon)."""
    # BEGIN PROBLEM 2
    first_digit = opponent_score//10
    second_digit = opponent_score%10
    bacon = 1 + max(first_digit, second_digit)
    return bacon
    # END PROBLEM 2


# Write your prime functions here!
def is_prime(turn_score):
    if turn_score > 1:
        if turn_score == 2 or turn_score == 3 or turn_score == 5:
            return True
        elif turn_score%2 == 0 or turn_score%3 == 0 or turn_score%5 == 0:
            return False
        else:
            return True
    else:
        return False

def next_prime_of(turn_score):
    turn_score += 1
    while not is_prime(turn_score):
        turn_score += 1
    return turn_score

def take_turn(num_rolls, opponent_score, dice=six_sided):
    """Simulate a turn rolling NUM_ROLLS dice, which may be 0 (Free Bacon).
    Return the points scored for the turn by the current player. Also
    implements the Hogtimus Prime and When Pigs Fly rules.

    num_rolls:       The number of dice rolls that will be made.
    opponent_score:  The total score of the opponent.
    dice:            A function of no args that returns an integer outcome.
    """
    # Leave these assert statements here; they help check for errors.
    assert type(num_rolls) == int, 'num_rolls must be an integer.'
    assert num_rolls >= 0, 'Cannot roll a negative number of dice in take_turn.'
    assert num_rolls <= 10, 'Cannot roll more than 10 dice.'
    assert opponent_score < 100, 'The game should be over.'
    # BEGIN PROBLEM 2
    turn_score = 0
    if num_rolls == 0:
        turn_score = free_bacon(opponent_score)
    else:
        turn_score = roll_dice(num_rolls, dice)
    if is_prime(turn_score):
        turn_score = next_prime_of(turn_score)
        
    if turn_score < (25-num_rolls): #When pigs fly
        return turn_score
    else:
        return 25-num_rolls
    
        
    return turn_score
    # END PROBLEM 2


def reroll(dice):
    """Return dice that return even outcomes and re-roll odd outcomes of DICE."""
    def rerolled():
        # BEGIN PROBLEM 3
        dice_turn = dice()
        count=0
        while (not dice_turn%2 == 0) and count==0:
            dice_turn = dice()
            count = 1
        return dice_turn  # Replace this statement
        # END PROBLEM 3
    return rerolled


def select_dice(score, opponent_score, dice_swapped):
    """Return the dice used for a turn, which may be re-rolled (Hog Wild) and/or
    swapped for four-sided dice (Pork Chop).

    DICE_SWAPPED is True if and only if four-sided dice are being used.
    """
    # BEGIN PROBLEM 4
    if dice_swapped == False:
        dice = six_sided
    else:
        dice = four_sided
    dice = six_sided  # Replace this statement
    # END PROBLEM 4
    
    if (score + opponent_score) % 7 == 0 and (score + opponent_score) > 0:
        dice = reroll(dice)
    return dice

def is_swap(score0, score1):
    """Returns whether one of the scores is double the other.
    """
    # BEGIN PROBLEM 4
    condition = False
    if score0>0 and score1>0:
        if score0*2 == score1 or score1*2 == score0:
            condition = True
    return condition
    # END PROBLEM 4
    
def other(player):
    """Return the other player, for a player PLAYER numbered 0 or 1.

    >>> other(0)
    1
    >>> other(1)
    0
    """
    return 1 - player


def play(strategy0, strategy1, score0=0, score1=0, goal=GOAL_SCORE):
    """Simulate a game and return the final scores of both players, with
    Player 0's score first, and Player 1's score second.

    A strategy is a function that takes two total scores as arguments
    (the current player's score, and the opponent's
    score), and returns a
    number of dice that the current player will roll this turn.

    strategy0:  The strategy function for Player 0, who plays first
    strategy1:  The strategy function for Player 1, who plays second
    score0   :  The starting score for Player 0
    score1   :  The starting score for Player 1
    """
    player = 0  # Which player is about to take a turn, 0 (first) or 1 (second)
    dice_swapped = False  # Whether 4-sided dice have been swapped for 6-sided
    # BEGIN PROBLEM 5


    while score0 < 100 and score1 < 100:

        if player == 0:
            score, opponent_score, strategy = score0, score1, strategy0
        elif player == 1:
            score, opponent_score, strategy = score1, score0, strategy1
            
        num_rolls = strategy(score, opponent_score)

        if num_rolls < 0:
            if dice_swapped == True:
                dice_swapped = False
            else:
                dice_swapped = True
        
        dice = select_dice(score, opponent_score, dice_swapped)

        if num_rolls < 0:
            score += 1
        elif num_rolls>= 0:
            score += take_turn(num_rolls, opponent_score, dice)

        if is_swap(score, opponent_score):
            score, opponent_score = opponent_score, score

        if player == 0:
            score0, score1 = score, opponent_score
        elif player == 1:
            score1, score0 = score, opponent_score

        player = other(player)

    # END PROBLEM 5
    return score0, score1


#######################
# Phase 2: Strategies #
#######################

def always_roll(n):
    """Return a strategy that always rolls N dice.

    A strategy is a function that takes two total scores as arguments
    (the current player's score, and the opponent's score), and returns a
    number of dice that the current player will roll this turn.

    >>> strategy = always_roll(5)
    >>> strategy(0, 0)
    5
    >>> strategy(99, 99)
    5
    """
    def strategy(score, opponent_score):
        return n
    return strategy


def check_strategy_roll(score, opponent_score, num_rolls):
    """Raises an error with a helpful message if NUM_ROLLS is an invalid
    strategy output. All strategy outputs must be integers from -1 to 10.

    >>> check_strategy_roll(10, 20, num_rolls=100)
    Traceback (most recent call last):
     ...
    AssertionError: strategy(10, 20) returned 100 (invalid number of rolls)

    >>> check_strategy_roll(20, 10, num_rolls=0.1)
    Traceback (most recent call last):
     ...
    AssertionError: strategy(20, 10) returned 0.1 (not an integer)

    >>> check_strategy_roll(0, 0, num_rolls=None)
    Traceback (most recent call last):
     ...
    AssertionError: strategy(0, 0) returned None (not an integer)
    """
    msg = 'strategy({}, {}) returned {}'.format(
        score, opponent_score, num_rolls)
    assert type(num_rolls) == int, msg + ' (not an integer)'
    assert -1 <= num_rolls <= 10, msg + ' (invalid number of rolls)'


def check_strategy(strategy, goal=GOAL_SCORE):
    """Checks the strategy with all valid inputs and verifies that the
    strategy returns a valid input. Use `check_strategy_roll` to raise
    an error with a helpful message if the strategy returns an invalid
    output.

    >>> def fail_15_20(score, opponent_score):
    ...     if score != 15 or opponent_score != 20:
    ...         return 5
    ...
    >>> check_strategy(fail_15_20)
    Traceback (most recent call last):
     ...
    AssertionError: strategy(15, 20) returned None (not an integer)
    >>> def fail_102_115(score, opponent_score):
    ...     if score == 102 and opponent_score == 115:
    ...         return 100
    ...     return 5
    ...
    >>> check_strategy(fail_102_115)
    >>> fail_102_115 == check_strategy(fail_102_115, 120)
    Traceback (most recent call last):
     ...
    AssertionError: strategy(102, 115) returned 100 (invalid number of rolls)
    """
    # BEGIN PROBLEM 6
    score=0
    opponent_score=0
    num_rolls=0
    while score <= goal:
        num_rolls=strategy(score, opponent_score)
        if num_rolls == None or num_rolls < -1  or num_rolls > 10 or num_rolls%1 != 0:
            check_strategy_roll(score, opponent_score, num_rolls)
        opponent_score += 1
        if opponent_score == goal+1:
            score += 1
            opponent_score = 0
    # END PROBLEM 6


# Experiments

def make_averaged(fn, num_samples=1000):
    """Return a function that returns the average_value of FN when called.

    To implement this function, you will have to use *args syntax, a new Python
    feature introduced in this project.  See the project description.

    >>> dice = make_test_dice(3, 1, 5, 6)
    >>> averaged_dice = make_averaged(dice, 1000)
    >>> averaged_dice()
    3.75
    """
    # BEGIN PROBLEM 7
    def average_function(*args):
        count = 0
        total=0
        while count < num_samples:
            total += fn(*args)
            count = count + 1
        total = total/num_samples
        return total
    return average_function
    # END PROBLEM 7


def max_scoring_num_rolls(dice=six_sided, num_samples=1000):
    """Return the number of dice (1 to 10) that gives the highest average turn
    score by calling roll_dice with the provided DICE over NUM_SAMPLES times.
    Assume that the dice always return positive outcomes.

    >>> dice = make_test_dice(3)
    >>> max_scoring_num_rolls(dice)
    10
    """
    # BEGIN PROBLEM 8
    num_rolls=10
    previous_average = 0
    return_rolls = 0
    averaged_dice = make_averaged(roll_dice, num_samples)
    while num_rolls > 0:
        average = averaged_dice(num_rolls, dice)
        if average >= previous_average:
            previous_average = average
            return_rolls = num_rolls
        num_rolls -= 1
    return return_rolls
    # END PROBLEM 8

def winner(strategy0, strategy1):
    """Return 0 if strategy0 wins against strategy1, and 1 otherwise."""
    score0, score1 = play(strategy0, strategy1)
    if score0 > score1:
        return 0
    else:
        return 1


def average_win_rate(strategy, baseline=always_roll(4)):
    """Return the average win rate of STRATEGY against BASELINE. Averages the
    winrate when starting the game as player 0 and as player 1.
    """
    win_rate_as_player_0 = 1 - make_averaged(winner)(strategy, baseline)
    win_rate_as_player_1 = make_averaged(winner)(baseline, strategy)

    return (win_rate_as_player_0 + win_rate_as_player_1) / 2


def run_experiments():
    """Run a series of strategy experiments and report results."""
    if True:  # Change to False when done finding max_scoring_num_rolls
        six_sided_max = max_scoring_num_rolls(six_sided)
        print('Max scoring num rolls for six-sided dice:', six_sided_max)
        rerolled_max = max_scoring_num_rolls(reroll(six_sided))
        print('Max scoring num rolls for re-rolled dice:', rerolled_max)
        
    if True:  # Change to True to test always_roll(8)
        print('always_roll(8) win rate:', average_win_rate(always_roll(8)))
    
    if True:  # Change to True to test bacon_strategy
        print('bacon_strategy win rate:', average_win_rate(bacon_strategy))

    if True:  # Change to True to test swap_strategy
        print('swap_strategy win rate:', average_win_rate(swap_strategy))
    if True: # Change to True to test final_strategy
        print('final_strategy win rate:', average_win_rate(final_strategy))

    "*** You may add additional experiments as you wish ***"
    

# Strategies

def bacon_strategy(score, opponent_score, margin=8, num_rolls=4):
    """This strategy rolls 0 dice if that gives at least MARGIN points,
    and rolls NUM_ROLLS otherwise.
    """
    # BEGIN PROBLEM 9
    zero_roll_points = free_bacon(opponent_score)
    rolls = 0
    if zero_roll_points >= margin:
        rolls = 0
    else:
        rolls = num_rolls
    return rolls  # Replace this statement
    # END PROBLEM 9
check_strategy(bacon_strategy)


def swap_strategy(score, opponent_score, margin=8, num_rolls=4):
    """This strategy rolls 0 dice when it triggers a beneficial swap. It also
    rolls 0 dice if it gives at least MARGIN points. Otherwise, it rolls
    NUM_ROLLS.
    """
    # BEGIN PROBLEM 10
    zero_roll_points = free_bacon(opponent_score)
    rolls = 0
    if  opponent_score == (score+zero_roll_points)*2:
        rolls = 0
    elif (score+zero_roll_points) == opponent_score*2:
        rolls = num_rolls
    else:
        rolls = bacon_strategy(score, opponent_score, margin, num_rolls)
    return rolls  # Replace this statement
    # END PROBLEM 10
check_strategy(swap_strategy)


def final_strategy(score, opponent_score):
    """Write a brief description of your final strategy.

    *** YOUR DESCRIPTION HERE ***
    """
    # BEGIN PROBLEM 11
    bacon = free_bacon(opponent_score)

    if score > opponent_score: # If player is in lead get value of margin required to achieve goal
        margin = 100-score
        return swap_strategy(score, opponent_score, margin)

    elif score + bacon >= 100: # No need points greater than goal
        return 0

    elif (score + bacon)*2 == opponent_score: # Force to get benificial swap when free_bacon added to score
        return swap_strategy(score, opponent_score)
    
    elif not (score + bacon + opponent_score) % 7 == 0: # Avoid to give opponent re-rolled dice
        return swap_strategy(score, opponent_score, bacon)

    elif 2 * (score + 1) == opponent_score: # Taking advantage of Pork Chop in forcing a beneficial swap
        return -1

    else:
        return swap_strategy(score, opponent_score, 11, 10)
    # Replace this statement
    # END PROBLEM 11
check_strategy(final_strategy)


##########################
# Command Line Interface #
##########################

# NOTE: Functions in this section do not need to be changed. They use features
# of Python not yet covered in the course.

@main
def run(*args):
    """Read in the command-line argument and calls corresponding functions.

    This function uses Python syntax/techniques not yet covered in this course.
    """
    import argparse
    parser = argparse.ArgumentParser(description="Play Hog")
    parser.add_argument('--run_experiments', '-r', action='store_true',
                        help='Runs strategy experiments')

    args = parser.parse_args()

    if args.run_experiments:
        run_experiments()
