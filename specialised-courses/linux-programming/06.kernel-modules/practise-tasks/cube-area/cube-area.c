#include <linux/kernel.h>
#include <linux/module.h>
#include <linux/init.h>
#include <asm/i387.h>

int side = 11;
module_param(side, int, 0);

static int __init init(void) {
	printk(KERN_INFO "Cube side: %d\n", side);

	return 0;
}

static void __exit cleanup(void) {
	printk(KERN_INFO "Goobdye cruel world\n");
}

module_init(init);
module_exit(cleanup);
