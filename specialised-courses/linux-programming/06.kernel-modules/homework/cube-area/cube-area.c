#include <linux/kernel.h>
#include <linux/module.h>
#include <linux/init.h>

int side = 11;
module_param(side, int, 0);

static int pow(int num, int power) {
	if (power == 0) {
		return 1;
	}

	if (power % 2 == 0) {
		int result = pow(num, power / 2);
		return result * result;
	} else {
		return num * pow(num, power - 1);
	}
}

static int __init init(void) {
	int result = side * side * side;
	int fractionCnt = 6;
	int divisor = pow(10, fractionCnt);
	int decimalPart = result / divisor;
	int fractionPart = result % divisor;

	printk(KERN_INFO "Cube side: %d.%06d\n", decimalPart, fractionPart);

	return 0;
}

static void __exit cleanup(void) {
	printk(KERN_INFO "Goobdye cruel world\n");
}

module_init(init);
module_exit(cleanup);
