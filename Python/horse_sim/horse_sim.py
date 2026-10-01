"""
This Program is used to get the probabilities of the horses winning at different positions

The -2 on die rolls is due to the way my Unity game is set up
"""

from tqdm import trange
import time
import random
import secrets

sim_total = 100000
horse_total_spots = [3,6,8,10,12,14,12,10,8,6,3]

def sim_game(_horse_positions:list, _horses_scratched:list):
    """
    This function simulates one game and returns the winning horse
    """
    def move_horse_forward(horse_num: int):
        if horses_scratched[horse_num]:
            return
        horse_positions[horse_num] += 1

    def roll_die():
        die1 = secrets.choice(range(1,7))
        die2 = secrets.choice(range(1,7))
        roll = die1 + die2

        return roll

    
    horses_scratched = _horses_scratched.copy()
    horse_positions = _horse_positions.copy()

    #checks to see if any horses have been scratched
    horses_scratched_total = 0
    for num in horses_scratched:
        if num:
            horses_scratched_total += 1

    #scratches 4 horses at beginning of game
    while horses_scratched_total < 4:
        scratched_horse_index = roll_die() - 2
        if horses_scratched[scratched_horse_index] == 0 and horse_positions[scratched_horse_index] == 0:    #make sure it cant scratch if moved
            horses_scratched[scratched_horse_index] = 1
            horses_scratched_total += 1
        else:
            continue


    game_over = False
    while game_over != True:

        horse_index = roll_die() - 2
        move_horse_forward(horse_index)

        #ends game when a horse reaches the final spot
        if horse_positions[horse_index] > horse_total_spots[horse_index]:
            winning_horse = horse_index + 2
            #print(f"Horse {winning_horse} won")
            game_over = True
    return winning_horse
        
def sim(_horse_positions: list, _horses_scratched: list):
    """
    simulate {sim_total} games and updates hores_win
    
    :param _horse_positions: where the horses are located
    :param _horses_scratched: which horses are scratched
    """

    horse_positions = _horse_positions
    horses_scratched = _horses_scratched

    #prints horse positions and the probability of winning
    print(horse_positions)
    horse_wins = [0,0,0,0,0,0,0,0,0,0,0]
    for i in trange(sim_total):
        winning_horse = sim_game(horse_positions, horses_scratched)
        horse_wins[winning_horse - 2] += 1
    print(horse_wins)

    #finds range and prints percentages
    high: int = 0
    low: int = 1000000
    for horse, value in enumerate(horse_wins):
        if value > high:
            high = value
        if value < low:
            low = value
        print(f"Horse {horse + 2} percent wins: {(value/sim_total) * 100: .2f}")

    high_percent = high/sim_total * 100
    low_percent = low/sim_total * 100

    print(f'Range: {high_percent - low_percent:.2f}')
  
def main():

    horses_scratched = [0,0,0,0,0,0,0,0,0,0,0]
    horse_positions = [0,0,0,0,0,0,0,0,0,0,0]

    sim(horse_positions, horses_scratched)


if __name__ == "__main__":
    main()