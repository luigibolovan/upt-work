import json

global rules

partial = []
final = []

def find_year(year):
    decade_lower_limit = year // 10 * 10;
    decade_upper_limit = year // 10 * 10 + 10;
    yr_condition = ['year >= {:d}'.format(decade_lower_limit), 'year < {:d}'.format(decade_upper_limit)]

    for rule in rules:
        if rule['final']:
            continue
        if rule['condition'] == yr_condition:
            partial.append(rule['result'])
            return True

    print ('could not found rule for this decade')
    return False

def find_mood(mood):
    mood_condition = 'mood == {}'.format(mood)
    for rule in rules:
        if rule['final']:
            continue

        if rule['condition'] == mood_condition:
            partial.append(rule['result'])
            return True

    print ('could not find rule for this mood')
    return False


def search_for_partial_conclusions(year, mood):
    if find_year(year) and find_mood(mood):
        return True

    return False

def search_for_final_conclusions():
    for decade, mood in zip(partial[0::2], partial[1::2]):
        for rule in rules:
            if not rule['final']:
                continue
            if [decade, mood] == rule['condition']:
                final.append(rule['result'])
                return True
    
    return False

def get_user_input():
    year = int(input('year of birth = '))
    print('choose mood:\n1.happy\n2.exuberant\n3.energetic\n4.frantic\n5.sad\n6.depression\n7.calm\n8.contentment')
    int_mood = int(input('selected mood: '))
    if int_mood == 1:
        mood = 'happy'
    elif int_mood == 2:
        mood = 'exuberant'
    elif int_mood == 3:
        mood = 'energetic'
    elif int_mood == 4:
        mood = 'frantic'
    elif int_mood == 5:
        mood = 'sad'
    elif int_mood == 6:
        mood = 'depression'
    elif int_mood == 7:
        mood = 'calm'
    elif int_mood == 8:
        mood = 'contentment'
    else:
        print('not a mood')
        exit(1)

    return year, mood

def check_facts():
    found = False
    with open('facts.json') as facts_file:
        facts = json.load(facts_file)
    
    for conclusion in final:
        for fact in facts:
            if conclusion[1] == fact['age'] and conclusion[2] == fact['mood']:
                found = True
                print("Song name: {}".format(fact['name']))
                print("Song url: {}".format(fact['url']))

    if not found: 
        print("couldn't find anything for that decade and mood")
        return False
    else:
        return True

if __name__ == "__main__":
    with open('rules.json') as rules_file:
        rules = json.load(rules_file)

    year, mood = get_user_input()
    
    while True:
        found_partial_conclusions = search_for_partial_conclusions(year, mood)
        if not found_partial_conclusions:
            y_or_n = input("wanna try again?(y/n): ")
            if y_or_n == 'y':
                get_user_input()
                continue
            else:
                break

        found_final_conclusions = search_for_final_conclusions()
        if found_final_conclusions:
            if not check_facts():
                y_or_n = input("wanna try again?(y/n): ")
                if y_or_n == 'y':
                    get_user_input()
                else:
                    break
            else:
                break
        else:
            print('could not find final conclusions')
            break
