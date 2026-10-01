from tqdm import trange
import time
import random
import secrets

sim_total = 100000


def sim_game(_horse_positions, _horses_scratched):
    #region horse variables

    horse_spots = [3,6,8,10,12,14,12,10,8,6,3]
    horses_scratched = _horses_scratched.copy()
    horse_positions = _horse_positions.copy()
    horses_scratched_total = 0
    for num in horses_scratched:
        if num:
            horses_scratched_total += 1

    #endregion

    def move_horse_forward(horse_num: int):
        if horses_scratched[horse_num]:
            return
        horse_positions[horse_num] += 1

    def roll_die():
        die1 = secrets.choice(range(1,7))
        die2 = secrets.choice(range(1,7))

        roll = die1 + die2

        return roll

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


        if horse_positions[horse_index] > horse_spots[horse_index]:
            winning_horse = horse_index + 2
            #print(f"Horse {winning_horse} won")
            game_over = True
    return winning_horse
        


     
def main():

    horse_spots = [3,6,8,10,12,14,12,10,8,6,3]
    horses_scratched = [0,0,0,0,0,0,0,0,0,0,0]
    horse_positions = [0,0,0,0,0,0,0,0,0,0,0]

    # for horse, spot_total in enumerate(horse_spots):
    #     print(f'{horse, spot_total}')
    #     for spot in range(0, spot_total):
    #         horse_positions[horse] = spot
    #         print(horse_positions)
    #         sim(horse_positions, horses_scratched)
    #         horse_positions[horse] = 0

    #lets go for more final starting with 14 loop

    # for spot in range(0, 14):
    #     horse_positions[5] = spot
    #     sim(horse_positions, horses_scratched)

    for spot7 in range(0, 14):
        horse_positions[5] = spot7
        for pos6 in (range(0, horse_spots[4])):
            horse_positions[6] = pos6
            sim(horse_positions, horses_scratched)

def sim(_horse_positions: list, _horses_scratched: list):
    """
    simulate 1000000 games and updates hors_win
    passes both variables to sim function
    """
    horse_positions = _horse_positions
    horses_scratched = _horses_scratched

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
    print(high_percent)
    print(low_percent)
    print(f'Range: {high_percent - low_percent:.2f}')

if __name__ == "__main__":
    main()