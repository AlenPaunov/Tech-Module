<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
      if (isset($_GET['num'])) {
        $num = intval($_GET['num']);
        $oddNumbers;
        for ($i=$num; $i >= 1; $i--) {
          if ($i%2!=0) {
            $oddNumbers[]= $i;
          }
        }
        echo join(" ",$oddNumbers);
      }
    ?>
</body>
</html>
