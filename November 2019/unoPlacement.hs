data Color = Yellow | Green | Red | Blue
    deriving (Eq, Show)

data Card = Card { color :: Color, number :: Int}
    deriving (Eq, Show)

data Hand = Hand { cards :: [Card] }
    deriving (Eq, Show)

canPlace [] _ = False
canPlace hand@(x:xs) upcard | color x  == color upcard  = True
                            | number x == number upcard = True
                            | otherwise                 = canPlace xs upcard
 
--Examples
hand1 = [Card Blue 2, Card Yellow 5]
hand2 = [Card Yellow 1, Card Green 2, Card Red 3, Card Blue 4]
hand3 = [Card Yellow 0, Card Yellow 1, Card Yellow 2, Card Yellow 3, Card Yellow 4, Card Yellow 5, Card Yellow 6, Card Yellow 7, Card Yellow 8, Card Yellow 9]
hand4 = []

upcard1 = Card Yellow 1
upcard2 = Card Green 6